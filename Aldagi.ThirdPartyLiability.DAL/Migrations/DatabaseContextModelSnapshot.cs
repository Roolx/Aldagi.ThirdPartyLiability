﻿// <auto-generated />
using Aldagi.Common.Enums;
using Aldagi.ThirdPartyLiability.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Aldagi.ThirdPartyLiability.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ManufacturerId");

                    b.Property<int>("ManufacturingYear");

                    b.Property<string>("ModelName");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientDetailsId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PersonalId");

                    b.HasKey("ClientId");

                    b.HasIndex("ClientDetailsId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.ClientDetails", b =>
                {
                    b.Property<int>("ClientDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarId");

                    b.Property<string>("CarRegistrationNumber");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<int>("InternalUserId");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("TPLDetailsId");

                    b.HasKey("ClientDetailsId");

                    b.HasIndex("CarId");

                    b.HasIndex("TPLDetailsId");

                    b.ToTable("ClientDetails");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.InternalUser", b =>
                {
                    b.Property<int>("InternalUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("InternalUserId");

                    b.ToTable("InternalUsers");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.TPLDetails", b =>
                {
                    b.Property<int>("TplDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<int>("TPLTermId");

                    b.HasKey("TplDetailsId");

                    b.HasIndex("TPLTermId");

                    b.ToTable("TPLDetails");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.TPLTerm", b =>
                {
                    b.Property<int>("TPLTermId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Bonus");

                    b.Property<int>("InternalUserId");

                    b.Property<decimal>("Limit");

                    b.HasKey("TPLTermId");

                    b.HasIndex("InternalUserId");

                    b.ToTable("TPLTerms");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.Client", b =>
                {
                    b.HasOne("Aldagi.ThirdPartyLiability.DAL.Entities.ClientDetails", "ClientDetails")
                        .WithMany()
                        .HasForeignKey("ClientDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.ClientDetails", b =>
                {
                    b.HasOne("Aldagi.ThirdPartyLiability.DAL.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aldagi.ThirdPartyLiability.DAL.Entities.TPLDetails", "TPLDetails")
                        .WithMany()
                        .HasForeignKey("TPLDetailsId");
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.TPLDetails", b =>
                {
                    b.HasOne("Aldagi.ThirdPartyLiability.DAL.Entities.TPLTerm", "TPLTerm")
                        .WithMany()
                        .HasForeignKey("TPLTermId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aldagi.ThirdPartyLiability.DAL.Entities.TPLTerm", b =>
                {
                    b.HasOne("Aldagi.ThirdPartyLiability.DAL.Entities.InternalUser", "IdentityUser")
                        .WithMany("TPLTerms")
                        .HasForeignKey("InternalUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
