using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Database
{
    public class IReckonuDatabaseContext:DbContext
    {

        internal DbSet<Article> Articles { get; set; }
        internal DbSet<Product> Products { get; set; }
        public IReckonuDatabaseContext(DbContextOptions options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
