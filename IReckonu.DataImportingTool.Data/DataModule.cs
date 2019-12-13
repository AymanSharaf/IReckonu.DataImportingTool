using Autofac;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions.File;
using IReckonu.DataImportingTool.Data.File;
using IReckonu.DataImportingTool.Data.Json;
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
            builder.RegisterType<SaveFileService>().AsImplementedInterfaces();
            builder.RegisterType<GetFileService>().AsImplementedInterfaces();
            builder.RegisterDecorator<EnsurePathExistsFileSaveDecorator, ISaveFile>();
            builder.RegisterDecorator<EnsurePathExistsGetFileSerivceDecorator, IGetFile>();
            builder.RegisterType<JsonSaveService>().Keyed<ISave>(SaveTypes.JSON);
            builder.RegisterType<SaveComposite>().As<ISave>();

        }
    }
}
