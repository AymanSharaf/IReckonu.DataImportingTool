using IReckonu.DataImportingTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Abstractions.File
{
    public interface IFileDeserialzer
    {
        Task<List<ImportDataFileInput>> Deserialize(string filePath);
    }
}
