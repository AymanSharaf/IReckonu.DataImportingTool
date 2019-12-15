using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            DetachAllEntities();
            return result;
        }
        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Unchanged ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
