using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Abstractions.File
{
    public interface IMoveFile
    {
        void MoveFile(string fromPath, string toPath);
    }
}
