using IReckonu.DataImportingTool.Data.Abstractions.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.File
{
    public class MoveFileService : IMoveFile
    {
        public void MoveFile(string fromPath, string toPath)
        {
            System.IO.File.Move(fromPath, toPath);
        }
    }
}
