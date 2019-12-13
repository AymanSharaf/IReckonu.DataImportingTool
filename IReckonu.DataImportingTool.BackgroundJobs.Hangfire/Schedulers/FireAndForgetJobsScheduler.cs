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
        public void ContinueJobWith<T>(string parentJobId, Expression<Action<T>> methodCall)
        {
            BackgroundJob.ContinueJobWith(parentJobId , methodCall);
        }

        public void EnqueueJob<T>(Expression<Action<T>> methodCall)
        {
            BackgroundJob.Enqueue<T>(methodCall);
        }
    }
}
