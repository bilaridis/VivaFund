using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Helpers
{
    public static class DataObjectExtensions
    {
        public static List<T> ConvertToList<T>(DataTable datatable) where T : new()
        {
            var temp = new List<T>();
            try
            {
                var columnsNames = (from DataColumn dataColumn in datatable.Columns select dataColumn.ColumnName).ToList();
                temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => GetObject<T>(row, columnsNames));
                return temp;
            }
            catch
            {
                return temp;
            }

        }
        public static T GetObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                var properties = typeof(T).GetProperties();
                foreach (var objProperty in properties)
                {
                    var columnname = columnsName.Find(name => string.Equals(name, objProperty.Name, StringComparison.CurrentCultureIgnoreCase));
                    if (string.IsNullOrEmpty(columnname)) continue;
                    var value = row[columnname].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                        {
                            value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                            objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                        }
                        else
                        {
                            value = row[columnname].ToString().Replace("%", "");
                            objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            var props = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            for (var i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            var values = new object[props.Count];
            foreach (var item in data)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
    public static class Extensions
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            var item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(System.DayOfWeek))
                {
                    var day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else
                {
                    property.SetValue(item, row[property.Name], null);
                }
            }
            return item;
        }
    }
}
