using IReckonu.DataImportingTool.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data
{
    public class SaveComposite:ISave
    {
        private readonly IEnumerable<ISave> _saves;

        public SaveComposite(IEnumerable<ISave> saves)
        {
            _saves = saves;
        }

        public async Task Save<T>(T entity)
        {
            foreach (var saveInstance in _saves)
            {
                await saveInstance.Save(entity);
            }
        }
    }
}
