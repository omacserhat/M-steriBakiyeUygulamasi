using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MusteriBakiyeUygulamasi.DB.Entities;

namespace MusteriBakiyeUygulamasi.DB.Entities.MusteriBakiyeUygulamasiDbContext
{
    public partial class MusteriBakiyeUygulamasiContext : DbContext
    {
        public MusteriBakiyeUygulamasiContext()
        {
        }

        public MusteriBakiyeUygulamasiContext(DbContextOptions<MusteriBakiyeUygulamasiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; } = null!;
        public virtual DbSet<CustomerAccount> CustomerAccount { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LSTT7NJ\\MSSQLSERVER1;Database=CustomerDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.TckNo);

                entity.Property(e => e.TckNo).HasMaxLength(11);

                entity.Property(e => e.Birthday)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerAccount>(entity =>
            {
                entity.HasKey(e => e.TckNo);

                entity.Property(e => e.TckNo).HasMaxLength(11);

                entity.Property(e => e.AccountNumber).HasMaxLength(8);

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.TckNoNavigation)
                    .WithOne(p => p.CustomerAccount)
                    .HasForeignKey<CustomerAccount>(d => d.TckNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAccount_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
