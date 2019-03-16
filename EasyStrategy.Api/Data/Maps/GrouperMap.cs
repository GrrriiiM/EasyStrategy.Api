using EasyStrategy.Domain.Groupers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Data.Maps
{
    public class GrouperMap : IEntityTypeConfiguration<Grouper>
    {
        public void Configure(EntityTypeBuilder<Grouper> builder)
        {
            builder.Property(_ => _.Name).IsRequired();
            builder.HasOne(_ => _.Type).WithMany().IsRequired();
        }
    }
}