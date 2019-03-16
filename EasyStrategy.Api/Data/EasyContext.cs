using EasyStrategy.Api.Data.Maps;
using EasyStrategy.Domain.Groupers;
using EasyStrategy.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyStrategy.Api.Data
{
    public class EasyContext : DbContext
    {
        public EasyContext(DbContextOptions<EasyContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<GrouperType> GrouperTypes { get; set; }
        public DbSet<Grouper> Groupers { get; set; }
        public DbSet<GrouperAggregation> GrouperAggregations { get; set; }
        public DbSet<GrouperAggregationGrouper> GrouperAggregationGroupers { get; set; }
        public DbSet<SaleIntervalType> SaleIntervalTypes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleTarget> SaleTargets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GrouperType>(new GrouperTypeMap().Configure);
            modelBuilder.Entity<Grouper>(new GrouperMap().Configure);
            modelBuilder.Entity<GrouperAggregation>(new GrouperAggregationMap().Configure);
            modelBuilder.Entity<GrouperAggregationGrouper>(new GrouperAggregationGrouperMap().Configure);
            modelBuilder.Entity<Sale>(new SaleMap().Configure);
        }
        
    }
}