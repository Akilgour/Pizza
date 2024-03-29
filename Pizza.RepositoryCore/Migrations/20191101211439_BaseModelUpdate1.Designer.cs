﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizza.RepositoryCore.Context;

namespace Pizza.RepositoryCore.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20191101211439_BaseModelUpdate1")]
    partial class BaseModelUpdate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pizza.RepositoryCore.Model.PizzaOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BaseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SauceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SizeInCM")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PizzaOrder");
                });
#pragma warning restore 612, 618
        }
    }
}
