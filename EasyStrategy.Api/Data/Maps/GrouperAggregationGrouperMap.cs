using EasyStrategy.Domain.Groupers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Data.Maps
{
    public class GrouperAggregationGrouperMap : IEntityTypeConfiguration<GrouperAggregationGrouper>
    {
        public void Configure(EntityTypeBuilder<GrouperAggregationGrouper> builder)
        {
            builder.HasOne(_ => _.Grouper).WithMany().IsRequired();
            builder.HasOne(_ => _.GrouperAggregation).WithMany(_ => _.GrouperAggregationGroupers).IsRequired();
        }
    }
}