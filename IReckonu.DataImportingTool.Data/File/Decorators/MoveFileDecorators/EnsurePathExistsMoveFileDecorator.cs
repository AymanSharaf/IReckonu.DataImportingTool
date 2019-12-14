using IReckonu.DataImportingTool.Data.Abstractions.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.File.Decorators.MoveFileDecorators
{
    public class EnsurePathExistsMoveFileDecorator : IMoveFile
    {
        private readonly IMoveFile _moveFile;

        public EnsurePathExistsMoveFileDecorator(IMoveFile moveFile)
        {
            _moveFile = moveFile;
        }

        public void MoveFile(string fromPath, string toPath)
        {
            var directory = Path.GetDirectoryName(toPath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(toPath);
            }
            _moveFile.MoveFile(fromPath, toPath);
        }
    }
}
