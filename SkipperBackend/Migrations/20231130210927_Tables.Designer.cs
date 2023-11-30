﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SkipperBack3.DBImport;

#nullable disable

namespace SkipperBack3.Migrations
{
    [DbContext(typeof(SkipperDBContext))]
    [Migration("20231130210927_Tables")]
    partial class Tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SkipperBack3.DBImport.BookedLesson", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid?>("LessonDurationId")
                        .HasColumnType("uuid")
                        .HasColumnName("lesson_duration_id");

                    b.Property<Guid?>("MentorId")
                        .HasColumnType("uuid")
                        .HasColumnName("mentor_id");

                    b.Property<Guid?>("MessengerId")
                        .HasColumnType("uuid")
                        .HasColumnName("messenger_id");

                    b.Property<long>("StartDate")
                        .HasColumnType("bigint")
                        .HasColumnName("start_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("type")
                        .HasDefaultValueSql("ARRAY['THEORY'::text, 'PRACTICE'::text, 'SOLUTION'::text]");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("BookedLessons_pkey");

                    b.HasIndex("LessonDurationId");

                    b.HasIndex("MessengerId");

                    b.HasIndex("UserId");

                    b.ToTable("BookedLessons");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Subcategories")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("74b50990-126f-4550-b6c0-845b8643b5df"),
                            Key = "development",
                            Name = "разработка",
                            Subcategories = new[] { "backend", "frontend" }
                        });
                });

            modelBuilder.Entity("SkipperBack3.DBImport.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Desctiption")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("MentorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.LessonDuration", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("LessonDurations_pkey");

                    b.ToTable("LessonDurations");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.LessonSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<string>("SlotId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Weekday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LessonSlots");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.Mentor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("CreatedAt")
                        .HasColumnType("interval");

                    b.Property<string>("CvInfoId")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lessons")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Messengers")
                        .HasColumnType("real");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("UpdatedAt")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.MentorStat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("LessonsCount")
                        .HasColumnType("integer");

                    b.Property<Guid?>("MentorId")
                        .HasColumnType("uuid");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<float>("ReviewersCount")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("MentorStats");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.MentorTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MentorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("MentorTags");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.MessengerInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("type")
                        .HasDefaultValueSql("ARRAY['Discord'::text, 'Telegram'::text, 'Skype'::text, 'VK'::text]");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("MessengerInfo_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("MessengerInfo", (string)null);
                });

            modelBuilder.Entity("SkipperBack3.DBImport.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("expires_at");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_revoked");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("token");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("RefreshTokens_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.TimeSLot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.ToTable("TimeSLot");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.User", b =>
                {
                    b.Property<Guid>("Uid")
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("bytea")
                        .HasColumnName("avatar");

                    b.Property<string>("Bio")
                        .HasColumnType("text")
                        .HasColumnName("bio");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("first_name");

                    b.Property<bool?>("IsMentor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("is_mentor")
                        .HasDefaultValueSql("false");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password_hash");

                    b.Property<string>("Post")
                        .HasColumnType("text")
                        .HasColumnName("post");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision")
                        .HasColumnName("rating");

                    b.Property<int>("ReviewsCount")
                        .HasColumnType("integer")
                        .HasColumnName("reviews_count");

                    b.Property<long>("UpdatedAt")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_at");

                    b.HasKey("Uid")
                        .HasName("Users_pkey");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.BookedLesson", b =>
                {
                    b.HasOne("SkipperBack3.DBImport.LessonDuration", "LessonDuration")
                        .WithMany("BookedLessons")
                        .HasForeignKey("LessonDurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("BookedLessons_lesson_duration_id_fkey");

                    b.HasOne("SkipperBack3.DBImport.MessengerInfo", "Messenger")
                        .WithMany("BookedLessons")
                        .HasForeignKey("MessengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("BookedLessons_messenger_id_fkey");

                    b.HasOne("SkipperBack3.DBImport.User", "User")
                        .WithMany("BookedLessons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("BookedLessons_user_id_fkey");

                    b.Navigation("LessonDuration");

                    b.Navigation("Messenger");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.MessengerInfo", b =>
                {
                    b.HasOne("SkipperBack3.DBImport.User", "User")
                        .WithMany("MessengerInfos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("MessengerInfo_user_id_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.RefreshToken", b =>
                {
                    b.HasOne("SkipperBack3.DBImport.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("RefreshTokens_user_id_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.LessonDuration", b =>
                {
                    b.Navigation("BookedLessons");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.MessengerInfo", b =>
                {
                    b.Navigation("BookedLessons");
                });

            modelBuilder.Entity("SkipperBack3.DBImport.User", b =>
                {
                    b.Navigation("BookedLessons");

                    b.Navigation("MessengerInfos");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}