﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonApi.Models;

namespace PersonApi.Migrations
{
    [DbContext(typeof(PersonContext))]
    partial class PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonApi.Models.Persons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ManagerIdId")
                        .HasColumnType("int");

                    b.Property<string>("PersonCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerIdId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonApi.Models.TimeOffs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("TimeOffs");
                });

            modelBuilder.Entity("PersonApi.Models.Persons", b =>
                {
                    b.HasOne("PersonApi.Models.Persons", "ManagerId")
                        .WithMany("Person")
                        .HasForeignKey("ManagerIdId");

                    b.Navigation("ManagerId");
                });

            modelBuilder.Entity("PersonApi.Models.TimeOffs", b =>
                {
                    b.HasOne("PersonApi.Models.Persons", "Person")
                        .WithMany("TimeOff")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PersonApi.Models.Persons", b =>
                {
                    b.Navigation("Person");

                    b.Navigation("TimeOff");
                });
#pragma warning restore 612, 618
        }
    }
}