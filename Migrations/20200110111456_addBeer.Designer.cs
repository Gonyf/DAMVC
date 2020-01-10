﻿// <auto-generated />
using System;
using DAMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAMVC.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200110111456_addBeer")]
    partial class addBeer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("DAMVC.Models.DB.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("ActualIBU")
                        .HasColumnType("REAL");

                    b.Property<float>("AlcPercent")
                        .HasColumnType("REAL");

                    b.Property<string>("Brewery")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DrinkingTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float?>("PerceivedBitterness")
                        .HasColumnType("REAL");

                    b.Property<float?>("PerceivedFruitiness")
                        .HasColumnType("REAL");

                    b.Property<float?>("PerceivedSweetness")
                        .HasColumnType("REAL");

                    b.Property<int>("SubmittedByUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("DAMVC.Models.DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAMVC.Models.DB.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}