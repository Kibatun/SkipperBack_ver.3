using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SkipperBack3.DBImport;

public partial class SkipperDBContext : DbContext
{
    public SkipperDBContext()
    {
    }

    public SkipperDBContext(DbContextOptions<SkipperDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookedLesson> BookedLessons { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<LessonDuration> LessonDurations { get; set; }
    public virtual DbSet<LessonSlot> LessonSlots { get; set; }
    public virtual DbSet<Mentor> Mentors { get; set; }
    public virtual DbSet<MentorStat> MentorStats { get; set; }
    public virtual DbSet<MentorTag> MentorTags { get; set; }
    public virtual DbSet<MessengerInfo> MessengerInfos { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<TimeSLot> TimeSLot { get; set; }
    public virtual DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=skipperDB;Port=5432;User Id=postgres;Password=1488;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookedLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("BookedLessons_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LessonDurationId).HasColumnName("lesson_duration_id");
            entity.Property(e => e.MentorId).HasColumnName("mentor_id");
            entity.Property(e => e.MessengerId).HasColumnName("messenger_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("ARRAY['THEORY'::text, 'PRACTICE'::text, 'SOLUTION'::text]")
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.LessonDuration).WithMany(p => p.BookedLessons)
                .HasForeignKey(d => d.LessonDurationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("BookedLessons_lesson_duration_id_fkey");

            entity.HasOne(d => d.Messenger).WithMany(p => p.BookedLessons)
                .HasForeignKey(d => d.MessengerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("BookedLessons_messenger_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.BookedLessons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("BookedLessons_user_id_fkey");
        });

        modelBuilder.Entity<LessonDuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("LessonDurations_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<MessengerInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MessengerInfo_pkey");

            entity.ToTable("MessengerInfo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("ARRAY['Discord'::text, 'Telegram'::text, 'Skype'::text, 'VK'::text]")
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.User).WithMany(p => p.MessengerInfos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("MessengerInfo_user_id_fkey");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RefreshTokens_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.IsRevoked).HasColumnName("is_revoked");
            entity.Property(e => e.Token).HasColumnName("token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("RefreshTokens_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("Users_pkey");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("uid");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.IsMentor)
                .HasDefaultValueSql("false")
                .HasColumnName("is_mentor");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Post).HasColumnName("post");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewsCount).HasColumnName("reviews_count");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        });

        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = Guid.NewGuid(),
            Key = "development",
            Name = "разработка",
            Subcategories = new string[] { "backend", "frontend" }
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
