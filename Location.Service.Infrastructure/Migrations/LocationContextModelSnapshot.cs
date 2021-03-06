﻿// <auto-generated />
using System;
using Location.Service.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Location.Service.Infrastructure.Data.Migrations
{
    [DbContext(typeof(LocationContext))]
    partial class LocationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Location.Service.Core.Entities.BranchLocationCodeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsAutoCode")
                        .HasColumnType("boolean");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("UpdatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("BranchLocationCodeType");
                });

            modelBuilder.Entity("Location.Service.Core.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<double>("Area")
                        .HasColumnType("double precision");

                    b.Property<int>("AutoCodeOwn")
                        .HasColumnType("integer");

                    b.Property<string>("AutoCodeParent")
                        .HasColumnType("text");

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<int>("LocationLevelId")
                        .HasColumnType("integer");

                    b.Property<int?>("LocationTagId")
                        .HasColumnType("integer");

                    b.Property<string>("ManualCode")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentLocationId")
                        .HasColumnType("integer");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("UpdatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("LocationLevelId");

                    b.HasIndex("ParentLocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("HasNoLocationCode")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasNoLocationName")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasNoTagIdentity")
                        .HasColumnType("boolean");

                    b.Property<string>("LocationCode")
                        .HasColumnType("text");

                    b.Property<string>("LocationGroupIds")
                        .HasColumnType("text");

                    b.Property<string>("LocationLevelIds")
                        .HasColumnType("text");

                    b.Property<string>("LocationName")
                        .HasColumnType("text");

                    b.Property<double>("MaxArea")
                        .HasColumnType("double precision");

                    b.Property<double>("MinArea")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("integer");

                    b.Property<string>("TagIdentity")
                        .HasColumnType("text");

                    b.Property<Guid>("UpdatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("LocationFilter");
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentLocationGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("UpdatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentLocationGroupId");

                    b.ToTable("LocationGroup");
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentLocationLevelId")
                        .HasColumnType("integer");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("SystemId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UpdatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentLocationLevelId");

                    b.ToTable("LocationLevel");
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationLocationGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("LocationGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("UpdatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("LocationGroupId");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationLocationGroup");
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Identity")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("UpdatedByUserGuid")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("LocationTag");
                });

            modelBuilder.Entity("Location.Service.Core.Entities.Location", b =>
                {
                    b.HasOne("Location.Service.Core.Entities.LocationLevel", "LocationLevel")
                        .WithMany()
                        .HasForeignKey("LocationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Location.Service.Core.Entities.Location", "ParentLocation")
                        .WithMany("ChildLocations")
                        .HasForeignKey("ParentLocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationGroup", b =>
                {
                    b.HasOne("Location.Service.Core.Entities.LocationGroup", "ParentLocationGroup")
                        .WithMany("ChildLocationGroups")
                        .HasForeignKey("ParentLocationGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationLevel", b =>
                {
                    b.HasOne("Location.Service.Core.Entities.LocationLevel", "ParentLocationLevel")
                        .WithMany()
                        .HasForeignKey("ParentLocationLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationLocationGroup", b =>
                {
                    b.HasOne("Location.Service.Core.Entities.LocationGroup", "LocationGroup")
                        .WithMany("LocationLocationGroups")
                        .HasForeignKey("LocationGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Location.Service.Core.Entities.Location", "Location")
                        .WithMany("LocationLocationGroups")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Location.Service.Core.Entities.LocationTag", b =>
                {
                    b.HasOne("Location.Service.Core.Entities.Location", "Location")
                        .WithOne("LocationTag")
                        .HasForeignKey("Location.Service.Core.Entities.LocationTag", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
