using Autofac;
using Autofac.Extras.DynamicProxy;
using IReckonu.DataImportingTool.Application.ApplicationServices;
using IReckonu.DataImportingTool.Application.MessageHandlers;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                return new LoggerInterceptor(c.Resolve<ILogger>());
            }).AsSelf();

            builder.RegisterType<DataImportApplicationService>().AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggerInterceptor));
            builder.RegisterType<FileManagementApplicationService>().AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggerInterceptor));
            builder.RegisterType<DataProcessingApplicationService>().AsImplementedInterfaces().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggerInterceptor));
            builder.RegisterType<FileUploadedAsyncMessageHandler>().AsImplementedInterfaces();
            builder.Register(c =>
            {
                var log = new LoggerConfiguration()
                               .WriteTo.Console()
                               .WriteTo.File("..\\Log\\log.txt", rollingInterval: RollingInterval.Day,shared: true)
                               .CreateLogger();
                return log;
            }).As<ILogger>().SingleInstance();
        }
    }
}
