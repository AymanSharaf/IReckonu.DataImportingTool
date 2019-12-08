using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Database
{
    public class ReckonuDatabaseContextFactory : IDesignTimeDbContextFactory<IReckonuDatabaseContext>
    {
        public IReckonuDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IReckonuDatabaseContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=IReckonuDB;");

            return new IReckonuDatabaseContext(optionsBuilder.Options);
        }
    }
}
