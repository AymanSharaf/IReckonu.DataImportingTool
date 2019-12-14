using Hangfire;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.BackgroundJobs.Hangfire.Schedulers
{
    public class FireAndForgetJobsScheduler : IFireAndForgetJobsScheduler
    {
        public string  ContinueJobWith<T>(string parentJobId, Expression<Action<T>> methodCall)
        {
           return BackgroundJob.ContinueJobWith(parentJobId , methodCall);
        }

        public string EnqueueJob<T>(Expression<Action<T>> methodCall)
        {
           return BackgroundJob.Enqueue<T>(methodCall);
        }
    }
}
