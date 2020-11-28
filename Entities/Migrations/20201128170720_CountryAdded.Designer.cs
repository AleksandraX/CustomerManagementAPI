﻿// <auto-generated />
using System;
using CustomerManagementPortal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerManagementPortal.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20201128170720_CountryAdded")]
    partial class CountryAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerManagementPortal.Entities.Enums.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9bf2890-0cdc-4946-adf3-858d616a081f"),
                            Name = "New"
                        },
                        new
                        {
                            Id = new Guid("2f6ad0c2-6ecb-4556-9dc1-eeb0d034d646"),
                            Name = "Confirmed"
                        },
                        new
                        {
                            Id = new Guid("167ea0e7-f697-456b-affe-eaf206ff2c59"),
                            Name = "Packing"
                        },
                        new
                        {
                            Id = new Guid("c18b20dd-a2e3-4d65-89fb-8f698d7a70c3"),
                            Name = "OnItsWay"
                        },
                        new
                        {
                            Id = new Guid("0c391e12-4db3-44b3-ae18-d03daf1e7ca5"),
                            Name = "OutForDelivery"
                        },
                        new
                        {
                            Id = new Guid("05b40e38-bbb7-44a8-bca3-19e02361bfb2"),
                            Name = "Delivered"
                        },
                        new
                        {
                            Id = new Guid("aead409d-3c2b-4f38-809f-4b317adfe254"),
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc003aa0-8f29-4be3-a623-69fc9136e9d2"),
                            Age = 5,
                            Email = "sisi.kaczuszka@wp.pl",
                            Gender = 1,
                            LastName = "Murlik",
                            Name = "Sisi",
                            PhoneNumber = "666666666"
                        },
                        new
                        {
                            Id = new Guid("daa46f02-4e4e-4342-bd74-0714b77ed535"),
                            Age = 3,
                            Email = "amor.buziaczek@onet.pl",
                            Gender = 0,
                            LastName = "Murlik",
                            Name = "Amor",
                            PhoneNumber = "555-555-555"
                        },
                        new
                        {
                            Id = new Guid("e0219757-b2e6-46b3-855b-335f2d9a94cc"),
                            Age = 17,
                            Email = "prywatny.murlik@gmail.com",
                            Gender = 1,
                            LastName = "Murlik",
                            Name = "Paula",
                            PhoneNumber = "537843591"
                        },
                        new
                        {
                            Id = new Guid("5b686772-258f-412c-9c00-4d29fdef1fb7"),
                            Age = 21,
                            Email = "kacper.berganski@onet.com",
                            Gender = 0,
                            LastName = "Bergański",
                            Name = "Kacper",
                            PhoneNumber = "720860430"
                        },
                        new
                        {
                            Id = new Guid("c6e963ae-ca9e-4bcb-9c13-a58c2f7b0ffa"),
                            Age = 0,
                            Email = "",
                            Gender = 1,
                            LastName = "Bergańska",
                            Name = "Daria",
                            PhoneNumber = ""
                        },
                        new
                        {
                            Id = new Guid("46b94aac-2f6e-4b0f-b0ae-f18549b96b36"),
                            Age = 28,
                            Email = "aleksandra.czerwa@gmail.com",
                            Gender = 1,
                            LastName = "Czerwińska",
                            Name = "Aleksandra",
                            PhoneNumber = "506139325"
                        },
                        new
                        {
                            Id = new Guid("4c980cfa-ded9-4d64-82bd-3d461719249b"),
                            Age = 20,
                            Email = "j.czerwinska@o2.pl",
                            Gender = 1,
                            LastName = "Czerwińska",
                            Name = "Julia",
                            PhoneNumber = "512899657"
                        });
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderedByCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderedByCustomerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fc17f474-751b-4f22-b79a-261e27fb4a08"),
                            CreationDate = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderedByCustomerId = new Guid("dc003aa0-8f29-4be3-a623-69fc9136e9d2"),
                            Price = 200m,
                            StatusId = new Guid("c9bf2890-0cdc-4946-adf3-858d616a081f")
                        },
                        new
                        {
                            Id = new Guid("ba5cb36e-3f46-43f8-9798-68bf94aca68e"),
                            CreationDate = new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderedByCustomerId = new Guid("c6e963ae-ca9e-4bcb-9c13-a58c2f7b0ffa"),
                            Price = 100m,
                            StatusId = new Guid("c9bf2890-0cdc-4946-adf3-858d616a081f")
                        },
                        new
                        {
                            Id = new Guid("3f168c8a-5d53-4ff8-ace8-d54170cd1bdd"),
                            CreationDate = new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderedByCustomerId = new Guid("dc003aa0-8f29-4be3-a623-69fc9136e9d2"),
                            Price = 220m,
                            StatusId = new Guid("05b40e38-bbb7-44a8-bca3-19e02361bfb2")
                        });
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Address", b =>
                {
                    b.HasOne("CustomerManagementPortal.Entities.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Customer", b =>
                {
                    b.HasOne("CustomerManagementPortal.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Employee", b =>
                {
                    b.HasOne("CustomerManagementPortal.Entities.Models.Address", null)
                        .WithMany("Employees")
                        .HasForeignKey("AddressId");

                    b.HasOne("CustomerManagementPortal.Entities.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerManagementPortal.Entities.Models.Order", b =>
                {
                    b.HasOne("CustomerManagementPortal.Entities.Models.Customer", "OrderedByCustomer")
                        .WithMany()
                        .HasForeignKey("OrderedByCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CustomerManagementPortal.Entities.Enums.OrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
