using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Abstractions.File
{
    public interface IGetFile
    {
        Stream Get(string path);
    }
}
