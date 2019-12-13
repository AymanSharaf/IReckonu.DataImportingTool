using Autofac;
using IReckonu.DataImportingTool.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application
{
    public class ApplicationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataImportApplicationService>().AsImplementedInterfaces();
        }
    }
}
