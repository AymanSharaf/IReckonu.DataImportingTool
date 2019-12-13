using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hangfire;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using IReckonu.DataImportingTool.BackgroundJobs.Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using Topshelf;
using Topshelf.Autofac;

namespace IReckonu.DataImportingTool.ProcessingApplication
{
    class Program
    {
        public IConfiguration Configuration { get; set; }
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            var hostBuilder = new HostBuilder()
               .ConfigureAppConfiguration((hostContext, config) =>
               {
                   var builder = config
                         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory.ToString())
                        .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);
               })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                foreach (string dll in Directory.GetFiles(AssemblyDirectory, "*.dll"))
                {
                    builder.RegisterAssemblyModules(Assembly.LoadFile(dll));
                }

            });

            var container = builder.Build();
            var host = hostBuilder.Build();


            HostFactory.Run(hostConfigrator =>
            {
                hostConfigrator.Service<IBackgroundJobServer>(service =>
                {
                    service.ConstructUsing(settings =>
                    {
                        var service = host.Services.GetRequiredService<IBackgroundJobServer>();
                        var config = host.Services.GetService<IConfiguration>();
                        var configurator = new HangfireConfigurator(config);
                        configurator.Configure(builder);                      
                       
                        return service;
                    });
                    service.WhenStarted(s => s.Start());
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
