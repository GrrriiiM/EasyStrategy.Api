using EasyStrategy.Domain.Groupers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Data.Mappings
{
    internal class GrouperTypeMapping : IEntityTypeConfiguration<GrouperType>
    {
        public void Configure(EntityTypeBuilder<GrouperType> builder)
        {
            builder.Property(_ => _.Name).IsRequired();
        }
    }
}
