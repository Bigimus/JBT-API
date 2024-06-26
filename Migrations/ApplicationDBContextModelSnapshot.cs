﻿// <auto-generated />
using System;
using JBT_Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JBT_Server.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JBT_Server.Models.InventoryReportForm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IRFID")
                        .HasColumnType("int");

                    b.Property<int?>("ResourceID")
                        .HasColumnType("int");

                    b.Property<int>("UUID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ResourceID");

                    b.ToTable("IRF");
                });

            modelBuilder.Entity("JBT_Server.Models.Resource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("JBT_Server.Models.InventoryReportForm", b =>
                {
                    b.HasOne("JBT_Server.Models.Resource", "Resource")
                        .WithMany("IRF")
                        .HasForeignKey("ResourceID");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("JBT_Server.Models.Resource", b =>
                {
                    b.Navigation("IRF");
                });
#pragma warning restore 612, 618
        }
    }
}
