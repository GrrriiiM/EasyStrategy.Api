﻿using EasyStrategy.Domain.Groupers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Data.Maps
{
    public class GrouperTypeMap : IEntityTypeConfiguration<GrouperType>
    {
        public void Configure(EntityTypeBuilder<GrouperType> builder)
        {
            builder.Property(_ => _.Name).IsRequired();
        }
    }
}