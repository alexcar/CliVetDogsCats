﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CliVetDogsCatsContext))]
    [Migration("20230416094457_reationship-category-brand")]
    partial class reationshipcategorybrand
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Complement")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Id");

                    b.HasIndex("ZipCode");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("IsVeterinarian")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid?>("WorkShiftId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Name");

                    b.HasIndex("WorkShiftId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("CostValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProfitMargin")
                        .HasColumnType("int");

                    b.Property<decimal>("SaleValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<decimal>("CostValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("ProductEntryHeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductEntryHeaderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductEntry", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductEntryHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductEntryHeader", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Trade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.WorkShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("CreatedDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Friday")
                        .HasColumnType("bit");

                    b.Property<byte?>("FridayFrom")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("FridayTo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Monday")
                        .HasColumnType("bit");

                    b.Property<byte?>("MondayFrom")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("MondayTo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Saturday")
                        .HasColumnType("bit");

                    b.Property<byte?>("SaturdayFrom")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("SaturdayTo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Sunday")
                        .HasColumnType("bit");

                    b.Property<byte?>("SundayFrom")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("SundayTo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Thursday")
                        .HasColumnType("bit");

                    b.Property<byte?>("ThursdayFrom")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("ThursdayTo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("bit");

                    b.Property<byte?>("TuesdayFrom")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("TuesdayTo")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("bit");

                    b.Property<byte?>("WednesdayFrom")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("WednesdayTo")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("WorkShift", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Brands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.WorkShift", "WorkShift")
                        .WithMany("Employees")
                        .HasForeignKey("WorkShiftId");

                    b.Navigation("Address");

                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.ProductEntry", b =>
                {
                    b.HasOne("Domain.Entities.ProductEntryHeader", "ProductEntryHeader")
                        .WithMany("ProductsEntry")
                        .HasForeignKey("ProductEntryHeaderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("ProductsEntry")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductEntryHeader");
                });

            modelBuilder.Entity("Domain.Entities.ProductEntryHeader", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("ProductsEntryHeader")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Supplier", "Supplier")
                        .WithMany("ProductsEntryHeader")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domain.Entities.Supplier", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("ProductsEntryHeader");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductsEntry");
                });

            modelBuilder.Entity("Domain.Entities.ProductEntryHeader", b =>
                {
                    b.Navigation("ProductsEntry");
                });

            modelBuilder.Entity("Domain.Entities.Supplier", b =>
                {
                    b.Navigation("ProductsEntryHeader");
                });

            modelBuilder.Entity("Domain.Entities.WorkShift", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
