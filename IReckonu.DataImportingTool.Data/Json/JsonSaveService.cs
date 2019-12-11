using IReckonu.DataImportingTool.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Json
{
    public class JsonSaveService : ISave
    {
        public JsonSaveService()
        {

        }
        public Task Save<T>(T enity)
        {
            throw new NotImplementedException();
        }
    }
}
