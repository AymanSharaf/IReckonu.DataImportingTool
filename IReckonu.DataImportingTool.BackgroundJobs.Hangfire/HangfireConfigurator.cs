using Autofac;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.BackgroundJobs.Hangfire
{
    public class HangfireConfigurator
    {
        private readonly IConfiguration configuration;

        public HangfireConfigurator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void Configure(ContainerBuilder builder) 
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"))
                                      .UseActivator(new HangfireAutofacActivator(builder))
                                      .UseColouredConsoleLogProvider();
        }
    }
}
