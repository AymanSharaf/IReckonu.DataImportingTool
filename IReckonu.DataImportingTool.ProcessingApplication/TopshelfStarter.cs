using Autofac;
using Castle.Core.Configuration;
using IReckonu.DataImportingTool.Application.Abstractions.MessageHandlers;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Messaging.Abstractions;
using IReckonu.DataImportingTool.Messaging.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                hostConfigrator.Service<IMessagingBus>(service =>
                {
                    service.ConstructUsing(settings =>
                    {
                        var service = host.Services.GetRequiredService<IMessagingBus>();
                        return service;
                    });
                    service.WhenStarted(async s =>
                    {
                        var fileUploadedHandler = host.Services.GetService<IFileUploadedAsyncMessageHandler>();
                        var databaseInitializer = host.Services.GetService<IDatabaseInitializer>();
                        await databaseInitializer.Initialize();
                        s.SubscribeAsync<FileUploaded>($"{Assembly.GetExecutingAssembly().GetName().Name}.FileUploaded", fileUploadedHandler.Handle);

                    });
                    service.WhenStopped(service => { });
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
