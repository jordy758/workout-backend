﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workout.Infrastructure.Persistence;

#nullable disable

namespace Workout.Infrastructure.Migrations
{
    [DbContext(typeof(WorkoutDbContext))]
    [Migration("20230422203738_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Workout.Domain.Exercise.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("varchar(350)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TargetedMuscles")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Exercises", (string)null);
                });

            modelBuilder.Entity("Workout.Domain.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Workout.Domain.WorkoutPlan.WorkoutPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("varchar(350)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("WorkoutPlans", (string)null);
                });

            modelBuilder.Entity("Workout.Domain.WorkoutPlan.WorkoutPlan", b =>
                {
                    b.OwnsMany("Workout.Domain.WorkoutPlan.Entities.WorkoutPlanSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)")
                                .HasColumnName("WorkoutSectionId");

                            b1.Property<Guid>("WorkoutPlanId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(350)
                                .HasColumnType("varchar(350)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.HasKey("Id", "WorkoutPlanId");

                            b1.HasIndex("WorkoutPlanId");

                            b1.ToTable("WorkoutPlanSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("WorkoutPlanId");

                            b1.OwnsMany("Workout.Domain.WorkoutPlan.Entities.ExerciseInstruction", "ExerciseInstructions", b2 =>
                                {
                                    b2.Property<Guid>("WorkoutSectionId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("WorkoutId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("Id")
                                        .HasColumnType("char(36)")
                                        .HasColumnName("ExerciseInstructionId");

                                    b2.Property<string>("Description")
                                        .HasMaxLength(350)
                                        .HasColumnType("varchar(350)");

                                    b2.Property<Guid>("ExerciseId")
                                        .HasColumnType("char(36)");

                                    b2.Property<int>("Reps")
                                        .HasColumnType("int");

                                    b2.Property<int>("Sets")
                                        .HasColumnType("int");

                                    b2.HasKey("WorkoutSectionId", "WorkoutId", "Id");

                                    b2.ToTable("ExerciseInstructions", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("WorkoutSectionId", "WorkoutId");
                                });

                            b1.Navigation("ExerciseInstructions");
                        });

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
