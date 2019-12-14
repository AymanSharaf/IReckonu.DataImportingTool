using IReckonu.DataImportingTool.Data.Abstractions.File;
using IReckonu.DataImportingTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Json
{
    public class JsonDeserializerService : IFileDeserialzer
    {
        public Task<List<T>> Deserialize<T>(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImportDataFileInput>> Deserialize(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
