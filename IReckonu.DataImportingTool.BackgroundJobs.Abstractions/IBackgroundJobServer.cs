using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.BackgroundJobs.Abstractions
{
    public interface IBackgroundJobServer
    {
        void Start();
        void Stop();
    }
}
