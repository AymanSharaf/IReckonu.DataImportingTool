using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using IReckonu.DataImportingTool.Messaging.Abstractions;
using IReckonu.DataImportingTool.Messaging.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace IReckonu.DataImportingTool.Application.ApplicationServices
{
    public class DataImportApplicationService : IDataImportApplicationService
    {
        private readonly IMessagingBus _messagingBus;
        private readonly IFileManagementApplicationService _fileManagementApplicationService;
        private readonly IConfiguration _configuration;

        public DataImportApplicationService(IMessagingBus messagingBus,
                                            IFileManagementApplicationService fileManagementApplicationService, 
                                            IConfiguration configration)
        {
            _messagingBus = messagingBus;
            _fileManagementApplicationService = fileManagementApplicationService;
            _configuration = configration;
        }

        public void ImportData(Stream streamInput)
        {
            var fileName = $"DataSheet-{DateTime.UtcNow.ToFileTimeUtc()}.csv";

            _fileManagementApplicationService.SaveFileToUnderProcessingFolder(fileName, streamInput);

            _messagingBus.Publish(new FileUploaded {FilePath= $"{fileName}" });
        }

    }
}
