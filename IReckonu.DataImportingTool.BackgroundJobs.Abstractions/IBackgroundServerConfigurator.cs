using System;

namespace IReckonu.DataImportingTool.BackgroundJobs.Abstractions
{
    public interface IBackgroundServerConfigurator
    {
        void Configure(IServiceProvider serviceProvider);
    }
}