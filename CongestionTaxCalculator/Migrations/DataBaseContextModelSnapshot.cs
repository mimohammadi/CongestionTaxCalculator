﻿// <auto-generated />
using System;
using CongestionTaxCalculator.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CongestionTaxCalculator.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CongestionTaxCalculator.Models.MaxTax.MaxTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MaxTaxes");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Models.TaxFee.TaxFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("Fee")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateOn")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("TaxFees");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Category")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaxFreeRules");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TaxFreeRule");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeDate", b =>
                {
                    b.HasBaseType("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeRule");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("TaxFreeDate");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeDayOfWeek", b =>
                {
                    b.HasBaseType("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeRule");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TaxFreeDayOfWeek");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeMonth", b =>
                {
                    b.HasBaseType("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeRule");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TaxFreeMonth");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeVehicle", b =>
                {
                    b.HasBaseType("CongestionTaxCalculator.Models.TaxFreeRules.TaxFreeRule");

                    b.Property<byte>("Vehicle")
                        .HasColumnType("tinyint");

                    b.HasDiscriminator().HasValue("TaxFreeVehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
