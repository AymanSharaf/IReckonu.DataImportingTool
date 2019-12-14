using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions.File;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.ApplicationServices
{
    public class FileManagementApplicationService : IFileManagementApplicationService
    {
        private readonly IConfiguration _configuration;
        private readonly ISaveFile _saveFile;
        private readonly IMoveFile _moveFile;

        public FileManagementApplicationService(IConfiguration configuration, ISaveFile saveFile, IMoveFile moveFile)
        {
            _configuration = configuration;
            _saveFile = saveFile;
            _moveFile = moveFile;
        }

        public void MoveFileToProcessedFolder(string fileName)
        {
            var filePath = $"{_configuration["StoredFilesPath"]}\\UnderProcessing\\{fileName}"; // Maybe move folderName to Configurations
            var toPath = $"{_configuration["StoredFilesPath"]}\\Processed\\{fileName}";
            _moveFile.MoveFile(filePath, toPath);

        }

        public void SaveFileToUnderProcessingFolder(string fileName, Stream fileStream)
        {
            var filePath = $"{_configuration["StoredFilesPath"]}\\UnderProcessing\\{fileName}";
            _saveFile.Save(filePath, fileStream);
        }
    }
}
