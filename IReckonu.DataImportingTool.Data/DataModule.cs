using Autofac;
using IReckonu.DataImportingTool.Data.Database;
using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var options = new DbContextOptionsBuilder<IReckonuDatabaseContext>();
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                //var factory = c.Resolve<IDesignTimeDbContextFactory<DbContext>>();
                //    return factory.CreateDbContext(null);
                return new IReckonuDatabaseContext(options.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<SaveService<Product>>().AsImplementedInterfaces();
        }
    }
}
