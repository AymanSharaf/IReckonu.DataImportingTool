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
            Directory.GetFiles(AssemblyDirectory, "*.dll").ToList().ForEach(a => Assembly.LoadFrom(a));

            var builder = new ContainerBuilder();

            var hostBuilder = new HostBuilder()
               .ConfigureAppConfiguration((hostContext, config) =>
               {
                   var builder = config
                         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory.ToString())
                        .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);
               }).ConfigureServices(services =>
               {
                   services.AddDistributedMemoryCache();
               })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                Directory.GetFiles(AssemblyDirectory, "*.dll").ToList()
                         .ForEach(a => builder.RegisterAssemblyModules(Assembly.LoadFile(a)));
            });

            TopshelfStarter.Start(builder.Build(), hostBuilder.Build());
        }

    }
}
