using Autofac;
using IReckonu.DataImportingTool.Data.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data
{
    public class DataModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileSaveService>().AsImplementedInterfaces();
        }
    }
}
