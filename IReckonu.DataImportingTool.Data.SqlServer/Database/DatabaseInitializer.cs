using IReckonu.DataImportingTool.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer.Database
{
    public class DatabaseInitializer: IDatabaseInitializer
    {
        private readonly IReckonuDatabaseContext _databaseContext;

        public DatabaseInitializer(IReckonuDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Initialize()
        {
           await _databaseContext.Database.MigrateAsync();
        }
    }
}
