using Autofac;
using Autofac.Extensions.DependencyInjection;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using Topshelf;

namespace IReckonu.DataImportingTool.ProcessingApplication
{
    /* Please Note : This application should be published as self-contained app(Deployment Type) and targets win-x64 (Target Runtime) 
       Not Tested here 
       To Install the windows service: dotnet IReckonu.DataImportingTool.ProcessingApplication.dll install
       To Start the windows service: dotnet IReckonu.DataImportingTool.ProcessingApplication.dll start
       To Stop the windows service: dotnet IReckonu.DataImportingTool.ProcessingApplication.dll stop
       To Uninstall the windows service: dotnet IReckonu.DataImportingTool.ProcessingApplication.dll uninstall
    */
    class Program
    {
        public IConfiguration Configuration { get; set; }
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
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
                    Assembly.LoadFrom(dll);
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
                        return service;
                    });
                    service.WhenStarted(s =>
                    {
                        var configurator = host.Services.GetService<IBackgroundServerConfigurator>();
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
