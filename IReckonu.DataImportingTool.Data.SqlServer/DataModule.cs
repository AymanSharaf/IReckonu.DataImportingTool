﻿using Autofac;
using IReckonu.DataImportingTool.Data.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer
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

                return new IReckonuDatabaseContext(options.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<SaveService>().AsImplementedInterfaces();
        }
    }
}