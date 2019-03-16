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
    [Migration("20190126220724_Init")]
    partial class Init
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

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long?>("TypeId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Groupers");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperAggregation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("GrouperAggregations");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperAggregationGrouper", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("GrouperAggregationId")
                        .IsRequired();

                    b.Property<long?>("GrouperAggregationId1");

                    b.Property<long?>("GrouperId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GrouperAggregationId");

                    b.HasIndex("GrouperAggregationId1");

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

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("GrouperTypes");
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.Grouper", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EasyStrategy.Domain.Groupers.GrouperAggregationGrouper", b =>
                {
                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperAggregation", "GrouperAggregation")
                        .WithMany()
                        .HasForeignKey("GrouperAggregationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EasyStrategy.Domain.Groupers.GrouperAggregation")
                        .WithMany("GrouperAggregationGroupers")
                        .HasForeignKey("GrouperAggregationId1")
                        .HasConstraintName("FK_GrouperAggregationGroupers_GrouperAggregations_GrouperAggre~1");

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
#pragma warning restore 612, 618
        }
    }
}
