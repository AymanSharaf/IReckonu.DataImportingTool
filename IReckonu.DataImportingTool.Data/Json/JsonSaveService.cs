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
        public async Task Save<T>(T entity) //SRP Violation suspect.... needs Review 
        {
            var entityName = entity.GetType().Name;
            var fileName = $"{entityName}.json";

            var existingFileContent = await _getFile.Get($"{_configuration["JsonDataPath"]}\\{fileName}");

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.ContractResolver = new ReadonlyJsonDefaultContractResolver();
            jsonSettings.ConstructorHandling= ConstructorHandling.AllowNonPublicDefaultConstructor;

            var existingJson = JsonConvert.DeserializeObject<List<T>>(existingFileContent, jsonSettings) ?? new List<T>();

            if (!existingJson.Any(a=>a.Equals(entity))) 
            {
                existingJson.Add(entity);
            }
            var serializedFinalString = JsonConvert.SerializeObject(existingJson, jsonSettings);
            System.IO.File.WriteAllText($"{_configuration["JsonDataPath"]}\\{fileName}", serializedFinalString); 

        }
    }
}
