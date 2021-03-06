﻿using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer.Database.Mappings
{
    public class DeliveryTimeMapping : IEntityTypeConfiguration<DeliveryTime>
    {
        public void Configure(EntityTypeBuilder<DeliveryTime> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
