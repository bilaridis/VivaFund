using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModelAccess.DomainModelAccess;

namespace DataAccessLayer
{
    public class ExampleForHelpers
    {
        private const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=CodingSchool;Integrated Security=True";

        public ExampleForHelpers()
        {
            // 1
            // Open connection
            using (SqlConnection c = new SqlConnection(ConnectionString))
            {
                c.Open();
                // 2
                // Create new DataAdapter
                using (SqlDataAdapter a = new SqlDataAdapter(
                    "SELECT * FROM Customers", c))
                {
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);

                    // 4
                    // Render data onto the screen
                    var list = Helpers.DataObjectExtensions.ConvertToList<Customer>(t);

                    var dataTable = Helpers.DataObjectExtensions.ToDataTable(list);
                }
            }
        }
    }
}
