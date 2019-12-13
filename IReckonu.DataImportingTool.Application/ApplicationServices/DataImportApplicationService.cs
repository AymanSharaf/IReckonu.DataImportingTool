using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.ApplicationServices
{
    public class DataImportApplicationService : IDataImportApplicationService
    {
        private readonly IFireAndForgetJobsScheduler fireAndForgetJobsScheduler;
        private readonly ISave _save;
        public DataImportApplicationService(IFireAndForgetJobsScheduler fireAndForgetJobsScheduler, ISave save)
        {
            _save = save;
            this.fireAndForgetJobsScheduler = fireAndForgetJobsScheduler;
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
             await _save.Save(targetGroup);
        }

        public void Test2()
        {
            fireAndForgetJobsScheduler.EnqueueJob<IDataImportApplicationService>(c=>c.Test());
        }
    }
}
