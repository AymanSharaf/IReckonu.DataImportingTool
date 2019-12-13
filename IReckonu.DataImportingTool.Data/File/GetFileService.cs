using IReckonu.DataImportingTool.Data.Abstractions.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.File
{
    public class GetFileService : IGetFile
    {
        public GetFileService()
        {
                
        }
        public Stream Get(string path)
        {
            if (Directory.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    return reader.BaseStream;
                } 
            }
            else
            {
                throw new InvalidOperationException("Path not found"); // Needs to be reconsidered
            }
        }

        
    }
}
