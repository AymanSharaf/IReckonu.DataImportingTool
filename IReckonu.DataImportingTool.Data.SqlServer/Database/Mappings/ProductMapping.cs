using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer.Database.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);
            builder.OwnsOne(a => a.Price);
            builder.HasOne<Color>("_color").WithMany().HasForeignKey(a => a.ColorId);
            builder.HasOne<DeliveryTime>("_deliveryTime").WithMany().HasForeignKey(a => a.DeliveryTimeId);
        }
    }
}
