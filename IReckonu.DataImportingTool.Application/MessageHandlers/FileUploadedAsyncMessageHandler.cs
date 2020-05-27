using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.Application.Abstractions.MessageHandlers;
using IReckonu.DataImportingTool.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.MessageHandlers
{
    public class FileUploadedAsyncMessageHandler : IFileUploadedAsyncMessageHandler
    {
        private readonly IDataProcessingApplicationService _dataProcessingApplicationService;
        private readonly IFileManagementApplicationService _fileManagementApplicationService;

        public FileUploadedAsyncMessageHandler(IDataProcessingApplicationService dataProcessingApplicationService,
                                               IFileManagementApplicationService fileManagementApplicationService)
        {
            _dataProcessingApplicationService = dataProcessingApplicationService;
            _fileManagementApplicationService = fileManagementApplicationService;
        }
        public async Task Handle(FileUploaded message)
        {
            await _dataProcessingApplicationService.ProcessFile(message.FilePath);
            _fileManagementApplicationService.MoveFileToProcessedFolder(message.FilePath);
        }
    }
}
