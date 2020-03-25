using Autofac;
using Hangfire;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.BackgroundJobs.Hangfire
{
    public class HangfireConfigurator:IBackgroundServerConfigurator
    {
        private readonly IConfiguration configuration;

        public HangfireConfigurator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Configure(IServiceProvider serviceProvider)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(configuration["DataImportingTool:DefaultConnection"])
                                      .UseActivator(new HangfireAutofacActivator(serviceProvider))
                                      .UseColouredConsoleLogProvider();
        }
    }
}
