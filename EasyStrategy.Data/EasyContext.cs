using EasyStrategy.Data.Mappings;
using EasyStrategy.Domain.Groupers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyStrategy.Data
{
    class EasyContext : DbContext
    {
        public EasyContext(DbContextOptions<EasyContext> options) : base(options)
        {
        }

        public DbSet<GrouperType> GrouperTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GrouperType>(new GrouperTypeMapping().Configure);
        }
    }
}