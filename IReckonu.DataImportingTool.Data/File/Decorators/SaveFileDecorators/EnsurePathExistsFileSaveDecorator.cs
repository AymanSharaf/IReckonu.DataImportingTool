using IReckonu.DataImportingTool.Data.Abstractions.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.File.Decorators
{
    public class EnsurePathExistsFileSaveDecorator : ISaveFile
    {
        private readonly ISaveFile _fileSave;

        public EnsurePathExistsFileSaveDecorator(ISaveFile fileSave)
        {
            _fileSave = fileSave;
        }
        public void Save(string path, Stream stream)
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory)) 
            {
                Directory.CreateDirectory(path);
            }
            _fileSave.Save(path,stream);
        }
    }
}
