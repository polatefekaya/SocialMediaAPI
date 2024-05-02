﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RosanicSocial.Infrastructure.DatabaseContext;

#nullable disable

namespace RosanicSocial.Infrastructure.Migrations.UserCritical
{
    [DbContext(typeof(UserCriticalDbContext))]
    partial class UserCriticalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("UserCritical")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RosanicSocial.Domain.Data.Entities.Report.UserBanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCritical")
                        .HasColumnType("bit");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UsersBans", "UserCritical");
                });

            modelBuilder.Entity("RosanicSocial.Domain.Data.Entities.Report.UserDangerZoneEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int?>("BanCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPermaBanned")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WarningCount")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("UsersDangerZones", "UserCritical");
                });

            modelBuilder.Entity("RosanicSocial.Domain.Data.Entities.Report.UserWarningEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WarningCategory")
                        .HasColumnType("int");

                    b.Property<int>("WarningLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UsersWarnings", "UserCritical");
                });

            modelBuilder.Entity("RosanicSocial.Domain.Data.Entities.UserPermissionEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActiviyVisible")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLastSeenActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPersonalizedAdsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProfileSeenHistoryActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRedirectMessagesSentFromStrangersActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("UsersPermissions", "UserCritical");
                });
#pragma warning restore 612, 618
        }
    }
}
