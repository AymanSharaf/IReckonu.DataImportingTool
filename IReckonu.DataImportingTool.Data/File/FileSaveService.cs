using IReckonu.DataImportingTool.Data.Abstractions.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.File
{
    public class FileSaveService : IFileSave
    {
        public FileSaveService()
        {
                
        }
        public void Save(string path, Stream stream)
        {
            if (!Directory.Exists(path)) 
            {
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }
    }
}
