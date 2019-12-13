using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
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

        public DataImportApplicationService(IFireAndForgetJobsScheduler fireAndForgetJobsScheduler)
        {
            this.fireAndForgetJobsScheduler = fireAndForgetJobsScheduler;
        }
        public void Test()
        {
            Console.WriteLine("Hello from the background");
        }

        public void Test2()
        {
            fireAndForgetJobsScheduler.EnqueueJob<IDataImportApplicationService>(c=>c.Test());
        }
    }
}
