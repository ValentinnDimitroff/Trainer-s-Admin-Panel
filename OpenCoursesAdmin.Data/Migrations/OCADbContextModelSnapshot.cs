﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using OpenCoursesAdmin.Data;
using OpenCoursesAdmin.Data.Enums;
using System;

namespace OpenCoursesAdmin.Data.Migrations
{
    [DbContext(typeof(OCADbContext))]
    partial class OCADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.CourseModels.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ModuleId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("LearningCourses");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.CourseModels.CourseInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<int>("ExternalId");

                    b.Property<int?>("FinalSurveyId");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("MiddleSurveyId");

                    b.Property<string>("Name");

                    b.Property<int?>("OnlineStudentsCount");

                    b.Property<int?>("OnsiteStudentsCount");

                    b.Property<int?>("SpectatorsCount");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("FinalSurveyId");

                    b.HasIndex("MiddleSurveyId");

                    b.ToTable("CourseInstances");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.CourseModels.CourseTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseInstanceId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourseInstanceId");

                    b.ToTable("CourseTopics");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.CourseModels.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LearningModulеs");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels.ConfigSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllowedIps");

                    b.Property<int>("ConfigurationId");

                    b.Property<string>("EndBefore");

                    b.Property<int>("ExternalId");

                    b.Property<string>("Password");

                    b.Property<string>("StartAfter");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("ConfigSchedules");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowMultipleParticipations");

                    b.Property<int>("DurationInSeconds");

                    b.Property<int>("ExternalId");

                    b.Property<bool>("KeepQuestionsOrder");

                    b.Property<string>("Name");

                    b.Property<int>("PollQuestionsCount");

                    b.Property<int>("PossibleAnswersCount");

                    b.Property<int>("QuestionsCount");

                    b.Property<int>("QuizId");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<int>("ExternalId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Quizs");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.QuizAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Correct");

                    b.Property<int>("ExternalId");

                    b.Property<int>("QuizQuiestionId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("QuizQuiestionId");

                    b.ToTable("QuizAnswers");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.QuizQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("CorrectAnswerPoints")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<int>("ExternalId");

                    b.Property<int>("QuizId");

                    b.Property<int>("Type")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("QuizQuestions");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.SurveyModels.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("CourseAverageScore");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int?>("ExternalId");

                    b.Property<bool?>("HasEnded");

                    b.Property<DateTime?>("StartDate");

                    b.Property<int>("SurveyType");

                    b.Property<double?>("TrainerAverageScore");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.SurveyModels.SurveyAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.Property<int>("Score");

                    b.Property<bool?>("Starred");

                    b.Property<int?>("StudentId");

                    b.Property<int>("SurveyId");

                    b.Property<int?>("SurveyQuestionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.HasIndex("SurveyQuestionId");

                    b.ToTable("SurveyAnswers");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.SurveyModels.SurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionType");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("SurveyQuestions");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenCoursesAdmin.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.CourseModels.Course", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.CourseModels.Module", "Module")
                        .WithMany("Courses")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.CourseModels.CourseInstance", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.CourseModels.Course", "Course")
                        .WithMany("CourseInstances")
                        .HasForeignKey("CourseId");

                    b.HasOne("OpenCoursesAdmin.Data.Models.SurveyModels.Survey", "FinalSurvey")
                        .WithMany()
                        .HasForeignKey("FinalSurveyId");

                    b.HasOne("OpenCoursesAdmin.Data.Models.SurveyModels.Survey", "MiddleSurvey")
                        .WithMany()
                        .HasForeignKey("MiddleSurveyId");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.CourseModels.CourseTopic", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.CourseModels.CourseInstance")
                        .WithMany("CourseTopics")
                        .HasForeignKey("CourseInstanceId");
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels.ConfigSchedule", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels.Configuration", "Configuration")
                        .WithMany("ConfigSchedules")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.ConfigurationModels.Configuration", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.QuizModels.Quiz", "Quiz")
                        .WithMany("Configurations")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.QuizAnswer", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.QuizModels.QuizQuestion", "QuizQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("QuizQuiestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.QuizModels.QuizQuestion", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.QuizModels.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OpenCoursesAdmin.Data.Models.SurveyModels.SurveyAnswer", b =>
                {
                    b.HasOne("OpenCoursesAdmin.Data.Models.SurveyModels.Survey")
                        .WithMany("SurveyAnswers")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OpenCoursesAdmin.Data.Models.SurveyModels.SurveyQuestion")
                        .WithMany("SurveyAnswers")
                        .HasForeignKey("SurveyQuestionId");
                });
#pragma warning restore 612, 618
        }
    }
}
