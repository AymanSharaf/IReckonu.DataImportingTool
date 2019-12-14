using IReckonu.DataImportingTool.Data.Abstractions.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.File
{
    public class SaveFileService : ISaveFile
    {
        public void Save(string path, Stream stream)
        {
            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                stream.CopyTo(fileStream);
            }
        }
    }
}
