using Autofac.Features.Indexed;
using IReckonu.DataImportingTool.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data
{
    public class SaveComposite : ISave
    {
        private readonly IIndex<SaveTypes, ISave> _saves;

        public SaveComposite(IIndex<SaveTypes, ISave> saves)
        {
            _saves = saves;
        }

        public async Task Save<T>(T entity)
        {
            // This could be more clean and generic 
            var sqlSave = _saves[SaveTypes.SQL];
            await sqlSave?.Save(entity);
            var jsonSave = _saves[SaveTypes.JSON];
            await jsonSave?.Save(entity);
        }
    }
}
