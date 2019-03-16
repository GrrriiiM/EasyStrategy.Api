﻿// <auto-generated />
using System;
using EasyStrategy.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyStrategy.Api.Migrations
{
    [DbContext(typeof(EasyContext))]
    [Migration("20190314233748_Description")]
    partial class Description
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Description");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Order");

                    b.Property<long?>("ParentId");

                    b.Property<string>("ReferenceColorRGB");

                    b.Property<string>("ReferenceIcon");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("GrouperTypes");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("GrouperAggregationId");

                    b.Property<long?>("GrouperTypeId");

                    b.Property<DateTime>("IntervalBegin");

                    b.Property<DateTime>("IntervalEnd");

                    b.Property<long?>("IntervalTypeId");

                    b.Property<string>("ReferenceGrouperDescription");

                    b.Property<long>("ReferenceGrouperId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("GrouperAggregationId");

                    b.HasIndex("GrouperTypeId");

                    b.HasIndex("IntervalTypeId");

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

            modelBuilder.Entity("EasyStrategy.Domain.Sales.SaleTarget", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("GrouperAggregationId");

                    b.Property<long?>("GrouperTypeId");

                    b.Property<DateTime>("IntervalBegin");

                    b.Property<DateTime>("IntervalEnd");

                    b.Property<long?>("IntervalTypeId");

                    b.Property<string>("ReferenceGrouperDescription");

                    b.Property<long>("ReferenceGrouperId");

                    b.Property<double>("Target");

                    b.HasKey("Id");

                    b.HasIndex("GrouperAggregationId");

                    b.HasIndex("GrouperTypeId");

                    b.HasIndex("IntervalTypeId");

                    b.ToTable("SaleTargets");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.Grouper", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.Grouper", "Parent")
                        .WithMany()
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
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.Sale", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperAggregation", "GrouperAggregation")
                        .WithMany()
                        .HasForeignKey("GrouperAggregationId");

                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType", "GrouperType")
                        .WithMany()
                        .HasForeignKey("GrouperTypeId");

                    b.HasOne("EasyStrategy.Domain.Sales.SaleIntervalType", "IntervalType")
                        .WithMany()
                        .HasForeignKey("IntervalTypeId");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Sales.SaleTarget", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperAggregation", "GrouperAggregation")
                        .WithMany()
                        .HasForeignKey("GrouperAggregationId");

                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType", "GrouperType")
                        .WithMany()
                        .HasForeignKey("GrouperTypeId");

                    b.HasOne("EasyStrategy.Domain.Sales.SaleIntervalType", "IntervalType")
                        .WithMany()
                        .HasForeignKey("IntervalTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
