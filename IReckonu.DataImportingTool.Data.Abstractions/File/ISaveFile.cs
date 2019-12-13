using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Abstractions.File
{
    public interface ISaveFile
    {
        void Save(string path, Stream stream);
    }
}
