using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Database.Mappings
{
    public class TargetGroupMapping : IEntityTypeConfiguration<TargetGroup>
    {
        public void Configure(EntityTypeBuilder<TargetGroup> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Articles);
            builder.Metadata.FindNavigation(nameof(TargetGroup.Articles)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
