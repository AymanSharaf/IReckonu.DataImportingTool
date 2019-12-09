using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data
{
    public class SaveService<T> : ISave<T>
    {
        private readonly IReckonuDatabaseContext databaseContext;

        public SaveService(IReckonuDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Save(T enity)
        {
            await databaseContext.AddAsync(enity);
            await databaseContext.SaveChangesAsync();
        }
    }
}
