﻿// <auto-generated />
using System;
using InventoryApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryApp.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20191116011720_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inventoryapp.Element", b =>
                {
                    b.Property<int>("InventoryNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAcquired");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Labor");

                    b.Property<int>("Location");

                    b.Property<decimal>("Retail");

                    b.Property<decimal>("Wholesale");

                    b.Property<decimal>("Worktime");

                    b.HasKey("InventoryNumber")
                        .HasName("PK_Elements");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("Inventoryapp.Fabrication", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("FabricationType");

                    b.Property<int>("InventoryNumber");

                    b.Property<decimal>("Retail");

                    b.Property<DateTime>("WorkCompleted");

                    b.HasKey("JobID")
                        .HasName("PK_Fabrication");

                    b.HasIndex("InventoryNumber");

                    b.ToTable("Fabrications");
                });

            modelBuilder.Entity("Inventoryapp.Fabrication", b =>
                {
                    b.HasOne("Inventoryapp.Element", "Element")
                        .WithMany()
                        .HasForeignKey("InventoryNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}