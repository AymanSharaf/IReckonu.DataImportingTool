using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.BackgroundJobs.Abstractions
{
    public interface IFireAndForgetJobsScheduler
    {
        string EnqueueJob<T>(Expression<Action<T>> methodCall);
        string ContinueJobWith<T>(string parentJobId,Expression<Action<T>> methodCall);
    }
}
