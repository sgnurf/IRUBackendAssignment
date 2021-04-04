﻿// <auto-generated />
using System;
using IReckonUAssignment.EntityFrameworkDAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IReckonUAssignment.EntityFrameworkDAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210404220254_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IReckonUAssignment.EntityFrameworkDAL.Entities.ArticleEntity", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ColorCode")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Q1")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Code");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("IReckonUAssignment.EntityFrameworkDAL.Entities.ProductEntity", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ArticleCode")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Color")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DeliveredIn")
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("DiscountPrice")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.HasKey("Key");

                    b.HasIndex("ArticleCode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("IReckonUAssignment.EntityFrameworkDAL.Entities.ProductEntity", b =>
                {
                    b.HasOne("IReckonUAssignment.EntityFrameworkDAL.Entities.ArticleEntity", "Article")
                        .WithMany("Products")
                        .HasForeignKey("ArticleCode");

                    b.Navigation("Article");
                });

            modelBuilder.Entity("IReckonUAssignment.EntityFrameworkDAL.Entities.ArticleEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
