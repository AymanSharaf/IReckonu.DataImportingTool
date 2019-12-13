using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.SqlServer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer.Services
{
    public class SaveChangesDecorator : ISave
    {
        private readonly ISave _save;
        private readonly IReckonuDatabaseContext _iReckonuDatabaseContext;

        public SaveChangesDecorator(ISave save, IReckonuDatabaseContext iReckonuDatabaseContext)
        {
            this._save = save;
            this._iReckonuDatabaseContext = iReckonuDatabaseContext;
        }
        public async Task Save<T>(T entity)
        {
            await _save.Save(entity);
            await _iReckonuDatabaseContext.SaveChangesAsync();
        }
    }
}
