using IReckonu.DataImportingTool.Data.Abstractions.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.File
{
    public class EnsurePathExistsGetFileSerivceDecorator : IGetFile
    {
        private readonly IGetFile _getFile;

        public EnsurePathExistsGetFileSerivceDecorator(IGetFile getFile)
        {
            _getFile = getFile;
        }
        public async Task<string> Get(string path)
        {
            var directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(path);
            }
            return await _getFile.Get(path);
        }
    }
}
