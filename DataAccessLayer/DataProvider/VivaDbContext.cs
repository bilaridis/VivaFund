using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataProvider
{
    public class VivaDbContext : DbContext
    {
        public VivaDbContext(string connectionString) :
            base(connectionString)
        {
        }
        public VivaDbContext(string connectionString, int commandTimeout) : base(connectionString, null)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = commandTimeout;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<VivaDbContext>(null);
            Configuration.LazyLoadingEnabled = false;

#if DEBUG
            Database.Log = m => Trace.Write(m);
#endif
        }
    }
}
