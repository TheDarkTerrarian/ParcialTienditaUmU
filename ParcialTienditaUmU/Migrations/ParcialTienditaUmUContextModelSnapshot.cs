﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParcialTienditaUmU.Data;

#nullable disable

namespace ParcialTienditaUmU.Migrations
{
    [DbContext(typeof(ParcialTienditaUmUContext))]
    partial class ParcialTienditaUmUContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ParcialTienditaUmU.Models.Orders", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderId"), 1L, 1);

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalPrice")
                        .HasColumnType("float");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("orderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ParcialTienditaUmU.Models.Products", b =>
                {
                    b.Property<int>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProduct"), 1L, 1);

                    b.Property<int?>("OrdersorderId")
                        .HasColumnType("int");

                    b.Property<int?>("SellssellId")
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("productPrice")
                        .HasColumnType("float");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("idProduct");

                    b.HasIndex("OrdersorderId");

                    b.HasIndex("SellssellId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ParcialTienditaUmU.Models.Sells", b =>
                {
                    b.Property<int>("sellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sellId"), 1L, 1);

                    b.Property<DateTime>("sellDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalToPay")
                        .HasColumnType("float");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sellId");

                    b.ToTable("Sells");
                });

            modelBuilder.Entity("ParcialTienditaUmU.Models.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"), 1L, 1);

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ParcialTienditaUmU.Models.Products", b =>
                {
                    b.HasOne("ParcialTienditaUmU.Models.Orders", null)
                        .WithMany("productsList")
                        .HasForeignKey("OrdersorderId");

                    b.HasOne("ParcialTienditaUmU.Models.Sells", null)
                        .WithMany("productsList")
                        .HasForeignKey("SellssellId");
                });

            modelBuilder.Entity("ParcialTienditaUmU.Models.Orders", b =>
                {
                    b.Navigation("productsList");
                });

            modelBuilder.Entity("ParcialTienditaUmU.Models.Sells", b =>
                {
                    b.Navigation("productsList");
                });
#pragma warning restore 612, 618
        }
    }
}
