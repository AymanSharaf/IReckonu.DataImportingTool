using IReckonu.DataImportingTool.Data.Abstractions.File;
using IReckonu.DataImportingTool.Data.File.CsvMappings;
using IReckonu.DataImportingTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;

namespace IReckonu.DataImportingTool.Data.File
{
    public class TinyCsvFileDeserializer : ICsvDeserializer
    {
        public TinyCsvFileDeserializer()
        {
                
        }
        public List<T> Deserialize<T>(string filePath) // needs Enhancement
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            ImportDataFileInputMapping csvMapper = new ImportDataFileInputMapping();
            CsvParser<ImportDataFileInput> csvParser = new CsvParser<ImportDataFileInput>(csvParserOptions, csvMapper);

            var result = csvParser
                .ReadFromFile(filePath, Encoding.ASCII)
                .ToList().Select(a=>a.Result).ToList();

            return result;
        }
    }
}
