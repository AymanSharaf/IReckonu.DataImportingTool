using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer
{
    public class SaveService : ISave
    {
        private readonly IReckonuDatabaseContext _databaseContext;

        public SaveService(IReckonuDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task Save<T>(T enity)
        {
            _databaseContext.Attach(enity);
        }
    }
}
