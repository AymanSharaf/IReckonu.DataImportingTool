using Autofac;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.BackgroundJobs.Hangfire
{
    public class HangfireAutofacActivator: JobActivator
    {
        private IContainer _container;
        private readonly ContainerBuilder _containerBuilder;
        private readonly IServiceProvider serviceProvider;

        public HangfireAutofacActivator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public override object ActivateJob(Type jobType)
        {
            return serviceProvider.GetService(jobType);
        }
    }
}
