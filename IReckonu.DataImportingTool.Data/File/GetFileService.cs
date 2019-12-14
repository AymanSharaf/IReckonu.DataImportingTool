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
        public async Task<string> Get(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    return await reader.ReadToEndAsync();
                }

            }
            catch
            {

                return string.Empty; // A workaround .. needs revisit
            }
        }


    }
}
