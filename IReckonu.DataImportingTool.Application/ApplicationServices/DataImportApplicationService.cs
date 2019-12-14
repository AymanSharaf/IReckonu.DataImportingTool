using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace IReckonu.DataImportingTool.Application.ApplicationServices
{
    public class DataImportApplicationService : IDataImportApplicationService
    {
        private readonly IFireAndForgetJobsScheduler _fireAndForgetJobsScheduler;
        private readonly IFileManagementApplicationService _fileManagementApplicationService;
        private readonly IConfiguration _configuration;

        public DataImportApplicationService(IFireAndForgetJobsScheduler fireAndForgetJobsScheduler,
                                            IFileManagementApplicationService fileManagementApplicationService, 
                                            IConfiguration configration)
        {
            _fireAndForgetJobsScheduler = fireAndForgetJobsScheduler;
            _fileManagementApplicationService = fileManagementApplicationService;
            _configuration = configration;
        }

        public void ImportData(Stream streamInput)
        {
            var fileName = $"DataSheet-{DateTime.UtcNow.ToFileTimeUtc()}.csv";
            _fileManagementApplicationService.SaveFileToUnderProcessingFolder(fileName, streamInput);

            var dataProcessingJobId = _fireAndForgetJobsScheduler.EnqueueJob<IDataProcessingApplicationService>(c =>
                                        c.ProcessFile($"{_configuration["StoredFilesPath"]}\\UnderProcessing\\{ fileName}"));

            _fireAndForgetJobsScheduler.ContinueJobWith<IFileManagementApplicationService>(dataProcessingJobId, c => c.MoveFileToProcessedFolder(fileName));
        }

    }
}
