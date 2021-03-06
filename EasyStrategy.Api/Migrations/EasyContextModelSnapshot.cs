﻿// <auto-generated />
using System;
using EasyStrategy.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyStrategy.Api.Migrations
{
    [DbContext(typeof(EasyContext))]
    partial class EasyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.Grouper", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<long?>("GrouperTypeId");

                    b.Property<bool>("IsTotal");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Order");

                    b.Property<long?>("ParentId");

                    b.Property<string>("ReferenceColorRGB");

                    b.Property<string>("ReferenceIcon");

                    b.Property<long?>("TypeId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GrouperTypeId");

                    b.HasIndex("ParentId");

                    b.HasIndex("TypeId");

                    b.ToTable("Groupers");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperAggregation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("GrouperAggregations");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperAggregationGrouper", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("GrouperAggregationId")
                        .IsRequired();

                    b.Property<long?>("GrouperId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GrouperAggregationId");

                    b.HasIndex("GrouperId");

                    b.ToTable("GrouperAggregationGroupers");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ChildId");

                    b.Property<string>("Description");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Order");

                    b.Property<string>("ReferenceColorRGB");

                    b.Property<string>("ReferenceIcon");

                    b.HasKey("Id");

                    b.HasIndex("ChildId")
                        .IsUnique();

                    b.ToTable("GrouperTypes");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("GrouperAggregationId");

                    b.Property<long?>("GrouperId");

                    b.Property<long?>("GrouperTypeId");

                    b.Property<DateTime>("IntervalBegin");

                    b.Property<DateTime>("IntervalEnd");

                    b.Property<long?>("IntervalTypeId");

                    b.Property<string>("ReferenceDescription");

                    b.Property<long>("ReferenceId");

                    b.HasKey("Id");

                    b.HasIndex("GrouperAggregationId");

                    b.HasIndex("GrouperId");

                    b.HasIndex("GrouperTypeId");

                    b.HasIndex("IntervalTypeId");

                    b.HasIndex("ReferenceId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.SaleIntervalType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SaleIntervalTypes");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.SaleNumberValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("SaleId");

                    b.Property<decimal>("Value");

                    b.Property<long?>("ValueTypeId");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.HasIndex("ValueTypeId");

                    b.ToTable("SaleNumberValues");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.SaleValueType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SaleValueTypes");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.Grouper", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType")
                        .WithMany("Groupers")
                        .HasForeignKey("GrouperTypeId");

                    b.HasOne("EasyStrategy.Domain.Groupers.Grouper", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId");

                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperAggregationGrouper", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperAggregation", "GrouperAggregation")
                        .WithMany("GrouperAggregationGroupers")
                        .HasForeignKey("GrouperAggregationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyStrategy.Domain.Groupers.Grouper", "Grouper")
                        .WithMany()
                        .HasForeignKey("GrouperId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperType", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType", "Child")
                        .WithOne("Parent")
                        .HasForeignKey("EasyStrategy.Domain.Groupers.GrouperType", "ChildId");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.Sale", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperAggregation", "GrouperAggregation")
                        .WithMany()
                        .HasForeignKey("GrouperAggregationId");

                    b.HasOne("EasyStrategy.Domain.Groupers.Grouper", "Grouper")
                        .WithMany()
                        .HasForeignKey("GrouperId");

                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType", "GrouperType")
                        .WithMany()
                        .HasForeignKey("GrouperTypeId");

                    b.HasOne("EasyStrategy.Domain.Sales.SaleIntervalType", "IntervalType")
                        .WithMany()
                        .HasForeignKey("IntervalTypeId");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.SaleNumberValue", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Sales.Sale", "Sale")
                        .WithMany("Numbers")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyStrategy.Domain.Sales.SaleValueType", "ValueType")
                        .WithMany()
                        .HasForeignKey("ValueTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
