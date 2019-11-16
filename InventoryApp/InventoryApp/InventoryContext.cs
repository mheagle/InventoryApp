using Inventoryapp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace InventoryApp
{
    class InventoryContext : DbContext
    {

        public DbSet<Element> Elements { get; set; }

        public DbSet<Fabrication> Fabrications { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Inventory2019;Integrated Security=True;Connect Timeout=30;");
       }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(a => a.InventoryNumber)
                 .HasName("PK_Elements");

                entity.Property(a => a.InventoryNumber)
                .ValueGeneratedOnAdd();

                entity.Property(a => a.Description)
                 .IsRequired()
                 .HasMaxLength(100);

                entity.Property(a => a.Location)
                 .IsRequired();

                entity.Property(a => a.Wholesale)
                 .IsRequired();

                entity.ToTable("Elements"); ;

            });

            modelBuilder.Entity<Fabrication>(entity =>
            {
                entity.HasKey(t => t.JobID)
                 .HasName("PK_Fabrication");

                entity.Property(t => t.JobID)
                 .ValueGeneratedOnAdd();

                entity.Property(t => t.Retail)
                 .IsRequired();

                entity.Property(t => t.FabricationType)
                .IsRequired();

                entity.HasOne(t => t.Element)
                .WithMany()
                .HasForeignKey(t => t.InventoryNumber);



        }); ;

        }
    }
}