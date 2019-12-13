using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IReckonu.DataImportingTool.BackgroundJobs.Hangfire;

namespace IReckonu.DataImportingTool.BackgroundJobs
{
    public class HangFireBackgroundJobServer : IBackgroundJobServer
    {

        private BackgroundJobServer _backgroundJobServer;
        public HangFireBackgroundJobServer()
        {
        }
        public void Start()
        {
            if (_backgroundJobServer == null)
            {
                _backgroundJobServer = new BackgroundJobServer();
            }
        }

        public void Stop()
        {
            if (_backgroundJobServer != null)
            {
                _backgroundJobServer.Dispose();
            }
        }
    }
}
