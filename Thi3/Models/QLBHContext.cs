﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Thi3.Models
{
    public partial class QLBHContext : DbContext
    {
        public QLBHContext()
        {
        }

        public QLBHContext(DbContextOptions<QLBHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhomHang> NhomHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-BAKRIIF\\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<NhomHang>(entity =>
            {
                entity.HasKey(e => e.MaNhomHang)
                    .HasName("PK__NhomHang__2C8866813B3C06AE");

                entity.ToTable("NhomHang");

                entity.Property(e => e.MaNhomHang).ValueGeneratedNever();

                entity.Property(e => e.TenNhomHang).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C89BB5093");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSP");

                entity.Property(e => e.TenSanPham).HasMaxLength(50);

                entity.HasOne(d => d.MaNhomHangNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNhomHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPham__MaNhomH__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
