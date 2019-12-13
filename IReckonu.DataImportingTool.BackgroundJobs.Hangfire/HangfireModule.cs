using Autofac;
using Hangfire;
using IReckonu.DataImportingTool.BackgroundJobs.Hangfire.Schedulers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.BackgroundJobs.Hangfire
{
    public class HangfireModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HangfireConfigurator>().AsSelf();
            builder.RegisterType<HangFireBackgroundJobServer>().AsImplementedInterfaces();
            builder.RegisterType<FireAndForgetJobsScheduler>().AsImplementedInterfaces();
           
        }
    }
}
