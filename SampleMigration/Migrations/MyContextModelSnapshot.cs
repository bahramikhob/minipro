﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleMigration;

namespace SampleMigration.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleMigration.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkOrderId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("SampleMigration.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("SampleMigration.Attachment", b =>
                {
                    b.HasOne("SampleMigration.WorkOrder", null)
                        .WithMany("Attachmentes")
                        .HasForeignKey("WorkOrderId");
                });

            modelBuilder.Entity("SampleMigration.WorkOrder", b =>
                {
                    b.Navigation("Attachmentes");
                });
#pragma warning restore 612, 618
        }
    }
}
