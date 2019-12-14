using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions.File;
using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.ApplicationServices
{
    public class DataImportApplicationService : IDataImportApplicationService
    {
        private readonly IFireAndForgetJobsScheduler _fireAndForgetJobsScheduler;
        private readonly IFileManagementApplicationService _fileManagementApplicationService;

        public DataImportApplicationService(IFireAndForgetJobsScheduler fireAndForgetJobsScheduler,
                                            IFileManagementApplicationService fileManagementApplicationService)
        {
            _fireAndForgetJobsScheduler = fireAndForgetJobsScheduler;
            _fileManagementApplicationService = fileManagementApplicationService;
        }

        public void ImportData(Stream streamInput)
        {
            var fileName = $"DataSheet-{DateTime.UtcNow.ToFileTimeUtc()}.csv";
            _fileManagementApplicationService.SaveFileToNotProcessedFolder(fileName, streamInput);
            var dataProcessingJobId = _fireAndForgetJobsScheduler.EnqueueJob<IDataProcessingApplicationService>(c => c.ProcessFile(fileName));
            _fireAndForgetJobsScheduler.ContinueJobWith<IFileManagementApplicationService>(dataProcessingJobId, c => c.MoveFileToProcessedFolder(fileName));
        }

        public async Task Test()
        {
            Console.WriteLine("Hello from the background");
            var targetGroup = new TargetGroup("babyBoooy");
            //var article = new Article("1", "22", new Brand("XYZ"), targetGroup);
            //targetGroup.AddArticle(article);
            //var deliveryTime = new DeliveryTime(TimeSpan.FromDays(1), TimeSpan.FromDays(3));
            //var color = new Color("Reeed");
            //article.AddProduct("Keey", new Price(100, 10), 10, color, deliveryTime);
            //article.AddProduct("Keey2", new Price(100, 10), 10, color, deliveryTime);
            // await _save.Save(targetGroup);
            //var fileName = "DataSheet-132205698851325804.csv";
            //var path = $"{_configuration["StoredFilesPath"]}{fileName}";
            //var result = _fileDeserialzer.Deserialize(path);
        }
    }
}
