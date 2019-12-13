using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions.File;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Json
{
    public class JsonSaveService : ISave
    {
        private readonly ISaveFile _saveFile;
        private readonly IConfiguration _configuration;
        private readonly IGetFile _getFile;

        public JsonSaveService(ISaveFile saveFile, IConfiguration configuration, IGetFile getFile)
        {
            _saveFile = saveFile;
            _configuration = configuration;
            _getFile = getFile;
        }
        public Task Save<T>(T entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var entityName = entity.GetType().Name;
            var fileName = $"{entityName}.json";
            System.IO.File.AppendAllText($"{_configuration["JsonDataPath"]}{fileName}", json); // This should be Decorated To make sure the path exists
            return Task.FromResult(0);

        }
    }
}
