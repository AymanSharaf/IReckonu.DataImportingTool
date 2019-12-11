using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer.Database
{
    public class ReckonuDatabaseContextFactory : IDesignTimeDbContextFactory<IReckonuDatabaseContext>
    {
        public IReckonuDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IReckonuDatabaseContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=IReckonuDB;"); // This is not Ok at all But i've to stop investing time in this point right now 

            return new IReckonuDatabaseContext(optionsBuilder.Options); // That's ok here because IReckonuDatabaseContext is considered a "Local Default"
        }
    }
}
