using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataProvider;

namespace DataProvider.DataProvider
{
    class DataProvider : IDataProvider
    {
        private readonly IRepository _repository;
        public DataProvider(string connectionString, int commandTImeout)
        {
            _repository = new Repository(new VivaDbContext(connectionString));
        }
    }
}
