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

        public HangfireAutofacActivator(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }
        public override object ActivateJob(Type jobType)
        {
            if (_container == null)
            {
                _container = _containerBuilder.Build();
            }
            return _container.Resolve(jobType);
        }
    }
}
