using Autofac;
using IReckonu.DataImportingTool.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Caching
{
    public class CachingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterDecorator<CachedGetService, IGet>();

        }
    }
}
