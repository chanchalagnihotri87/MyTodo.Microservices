﻿// <auto-generated />
using System;
using Goals.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Goals.API.Migrations
{
    [DbContext(typeof(GoalDbContext))]
    partial class GoalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Goals.API.Domain.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Plan")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProblemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwentyPercent")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completed = true,
                            Index = 0,
                            ProblemId = 1,
                            Text = "Correct in english",
                            TwentyPercent = true,
                            UserId = new Guid("16591e7e-c974-4512-88aa-af31e5230c93")
                        },
                        new
                        {
                            Id = 2,
                            Completed = true,
                            Index = 0,
                            ProblemId = 1,
                            Text = "Confidence in english",
                            TwentyPercent = true,
                            UserId = new Guid("16591e7e-c974-4512-88aa-af31e5230c93")
                        },
                        new
                        {
                            Id = 3,
                            Completed = true,
                            Index = 0,
                            ProblemId = 1,
                            Text = "Speaking fast",
                            TwentyPercent = true,
                            UserId = new Guid("16591e7e-c974-4512-88aa-af31e5230c93")
                        },
                        new
                        {
                            Id = 4,
                            Completed = false,
                            Index = 0,
                            ProblemId = 1,
                            Text = "Fluent in english",
                            TwentyPercent = false,
                            UserId = new Guid("16591e7e-c974-4512-88aa-af31e5230c93")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
