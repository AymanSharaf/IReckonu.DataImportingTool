using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer.Database
{
    public class IReckonuDatabaseContext : DbContext
    {

        internal DbSet<TargetGroup> TargetGroups { get; set; }
        internal DbSet<Brand> Brands { get; set; }
        internal DbSet<Color> Colors { get; set; }
        internal DbSet<DeliveryTime> DeliveryTimes { get; set; }
        internal DbSet<Article> Articles { get; set; }
        internal DbSet<Product> Products { get; set; }
        public IReckonuDatabaseContext(DbContextOptions options) : base(options)
        {
           // Database.EnsureCreated(); // Workaround because i couldn't get the migrations to work on time, Also Instead of this we can use Databse Project
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
