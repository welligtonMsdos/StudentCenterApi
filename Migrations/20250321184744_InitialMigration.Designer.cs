﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentCenterApi.src.Infrastructure.Data.Context;

#nullable disable

namespace StudentCenterApi.Migrations
{
    [DbContext(typeof(StudentCenterContext))]
    [Migration("20250321184744_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentCenterApi.src.Domain.Model.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("RequestType", (string)null);
                });

            modelBuilder.Entity("StudentCenterApi.src.Domain.Model.Solicitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("RequestTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestTypeId");

                    b.HasIndex("StatusId")
                        .HasDatabaseName("IX_StatusId");

                    b.HasIndex("StudentId")
                        .HasDatabaseName("IX_StudentId");

                    b.ToTable("Solicitation", (string)null);
                });

            modelBuilder.Entity("StudentCenterApi.src.Domain.Model.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("StudentCenterApi.src.Domain.Model.StudentCenterBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Page")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("StudentCenterBase", (string)null);
                });

            modelBuilder.Entity("StudentCenterApi.src.Domain.Model.Solicitation", b =>
                {
                    b.HasOne("StudentCenterApi.src.Domain.Model.RequestType", "RequestType")
                        .WithMany("Solicitation")
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentCenterApi.src.Domain.Model.Status", "Status")
                        .WithMany("Solicitation")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("StudentCenterApi.src.Domain.Model.RequestType", b =>
                {
                    b.Navigation("Solicitation");
                });

            modelBuilder.Entity("StudentCenterApi.src.Domain.Model.Status", b =>
                {
                    b.Navigation("Solicitation");
                });
#pragma warning restore 612, 618
        }
    }
}
