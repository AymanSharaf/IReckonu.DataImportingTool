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
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Products);
            builder.HasOne<TargetGroup>("_targetGroup").WithMany().HasForeignKey(a => a.TargetGroupId);
            builder.HasOne<Brand>("_brand").WithMany().HasForeignKey(a => a.BrandId);
            builder.Metadata.FindNavigation(nameof(Article.Products)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
