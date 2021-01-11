﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using functional.infrastructure.store.context;

namespace functional.infrastructure.store.context.migrations
{
    [DbContext(typeof(EventStoreDbContext))]
    partial class EventStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("functional.common.entities.EventStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("char(36)");

                    b.Property<int>("MessageType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("MessageType");

                    b.HasIndex("Timestamp");

                    b.ToTable("EventStore");
                });
#pragma warning restore 612, 618
        }
    }
}