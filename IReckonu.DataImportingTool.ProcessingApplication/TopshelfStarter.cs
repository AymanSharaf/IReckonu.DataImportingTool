using Autofac;
using Castle.Core.Configuration;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace IReckonu.DataImportingTool.ProcessingApplication
{
    public static class TopshelfStarter
    {
       internal static void Start(IContainer container, IHost host)
        {
            HostFactory.Run(hostConfigrator =>
            {
                hostConfigrator.Service<IBackgroundJobServer>(service =>
                {
                    service.ConstructUsing(settings =>
                    {
                        var service = host.Services.GetRequiredService<IBackgroundJobServer>();
                        return service;
                    });
                    service.WhenStarted(async s =>
                    {
                        var configurator = host.Services.GetService<IBackgroundServerConfigurator>();
                        var databaseInitializer = host.Services.GetService<IDatabaseInitializer>();
                        await databaseInitializer.Initialize();
                        configurator.Configure(host.Services);
                        s.Start();
                    });
                    service.WhenStopped(service => service.Stop());
                });

                hostConfigrator.RunAsLocalSystem()
                  .StartAutomatically();

                hostConfigrator.SetServiceName("IReckonu.DataImportingTool.DataProcessingApplication");
                hostConfigrator.SetDisplayName("IReckonu.DataImportingTool.DataProcessingApplication");
                hostConfigrator.SetDescription("IReckonu.DataImportingTool.DataProcessingApplication: Background server that uses Hangfire as to process data");
            });
        }
    }
}
