using EasyStrategy.Domain.Groupers;
using EasyStrategy.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Data.Maps
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasOne(_ => _.Grouper).WithMany().IsRequired(false);
            builder.HasIndex(_ => _.ReferenceId);
            builder.HasMany(_ => _.Numbers).WithOne(_ => _.Sale).OnDelete(DeleteBehavior.Cascade);
        }
    }
}