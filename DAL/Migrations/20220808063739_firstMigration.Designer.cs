﻿// <auto-generated />
using System;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApartmentMSDBContext))]
    [Migration("20220808063739_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Entities.Flat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<byte>("FloorNo")
                        .HasColumnType("tinyint");

                    b.Property<int>("HirerOrHostId")
                        .HasColumnType("int");

                    b.Property<string>("No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HirerOrHostId");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlatId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("VehicleNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlatId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Entities.UserPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersPassswords");
                });

            modelBuilder.Entity("Models.Entities.UtilityBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillNameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FlatId")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BillNameId");

                    b.HasIndex("FlatId");

                    b.ToTable("UtilityBills");
                });

            modelBuilder.Entity("Models.Entities.UtilityBillType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UtilityBillTypes");
                });

            modelBuilder.Entity("Models.Entities.Flat", b =>
                {
                    b.HasOne("Models.Entities.User", "HirerOrHost")
                        .WithMany()
                        .HasForeignKey("HirerOrHostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HirerOrHost");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.HasOne("Models.Entities.Flat", "Flat")
                        .WithMany()
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flat");
                });

            modelBuilder.Entity("Models.Entities.UserPassword", b =>
                {
                    b.HasOne("Models.Entities.User", "User")
                        .WithOne("Password")
                        .HasForeignKey("Models.Entities.UserPassword", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.UtilityBill", b =>
                {
                    b.HasOne("Models.Entities.UtilityBillType", "BillType")
                        .WithMany()
                        .HasForeignKey("BillNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Flat", "Flat")
                        .WithMany("UtilityBills")
                        .HasForeignKey("FlatId");

                    b.Navigation("BillType");

                    b.Navigation("Flat");
                });

            modelBuilder.Entity("Models.Entities.Flat", b =>
                {
                    b.Navigation("UtilityBills");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.Navigation("Password");
                });
#pragma warning restore 612, 618
        }
    }
}
