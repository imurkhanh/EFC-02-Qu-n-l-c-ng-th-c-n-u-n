﻿// <auto-generated />
using EFC_02.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFC_02.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFC_02.Entity.CongThuc", b =>
                {
                    b.Property<int>("CongThucId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CongThucId"));

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonAnId")
                        .HasColumnType("int");

                    b.Property<int>("NguyenLieuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("CongThucId");

                    b.HasIndex("MonAnId");

                    b.HasIndex("NguyenLieuId");

                    b.ToTable("CongThuc");
                });

            modelBuilder.Entity("EFC_02.Entity.LoaiMonAn", b =>
                {
                    b.Property<int>("LoaiMonAnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiMonAnId"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiMonAnId");

                    b.ToTable("LoaiMonAn");
                });

            modelBuilder.Entity("EFC_02.Entity.MonAn", b =>
                {
                    b.Property<int>("MonAnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonAnId"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiMonAnId")
                        .HasColumnType("int");

                    b.Property<string>("TenMon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonAnId");

                    b.HasIndex("LoaiMonAnId");

                    b.ToTable("MonAn");
                });

            modelBuilder.Entity("EFC_02.Entity.NguyenLieu", b =>
                {
                    b.Property<int>("NguyenLieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NguyenLieuId"));

                    b.Property<string>("TenNguyenLieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NguyenLieuId");

                    b.ToTable("NguyenLieu");
                });

            modelBuilder.Entity("EFC_02.Entity.CongThuc", b =>
                {
                    b.HasOne("EFC_02.Entity.MonAn", "MonAn")
                        .WithMany()
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFC_02.Entity.NguyenLieu", "NguyenLieu")
                        .WithMany()
                        .HasForeignKey("NguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonAn");

                    b.Navigation("NguyenLieu");
                });

            modelBuilder.Entity("EFC_02.Entity.MonAn", b =>
                {
                    b.HasOne("EFC_02.Entity.LoaiMonAn", "LoaiMonAn")
                        .WithMany("MonAn")
                        .HasForeignKey("LoaiMonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiMonAn");
                });

            modelBuilder.Entity("EFC_02.Entity.LoaiMonAn", b =>
                {
                    b.Navigation("MonAn");
                });
#pragma warning restore 612, 618
        }
    }
}
