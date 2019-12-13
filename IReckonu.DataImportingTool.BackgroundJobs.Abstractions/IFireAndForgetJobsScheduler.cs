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
        void EnqueueJob<T>(Expression<Action<T>> methodCall);
        void ContinueJobWith<T>(string parentJobId,Expression<Action<T>> methodCall);
    }
}
