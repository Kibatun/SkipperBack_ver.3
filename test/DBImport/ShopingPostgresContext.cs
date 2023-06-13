using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SkipperBack3.DBImport;

public partial class ShopingPostgresContext : DbContext
{
    public ShopingPostgresContext()
    {
    }

    public ShopingPostgresContext(DbContextOptions<ShopingPostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookedLesson> BookedLessons { get; set; }

    public virtual DbSet<LessonDuration> LessonDurations { get; set; }

    public virtual DbSet<MessengerInfo> MessengerInfos { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=shopingPostgres;Port=5432;User Id=postgres;Password=1488;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookedLesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("BookedLessons_pkey");

            entity.HasIndex(e => e.Lessondurationid, "BookedLessons_lessondurationid_key").IsUnique();

            entity.HasIndex(e => e.Messengerid, "BookedLessons_messengerid_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Lessondurationid).HasColumnName("lessondurationid");
            entity.Property(e => e.Mentorid).HasColumnName("mentorid");
            entity.Property(e => e.Messengerid).HasColumnName("messengerid");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("ARRAY['THEORY'::text, 'PRACTICE'::text, 'SOLUTION'::text]")
                .HasColumnName("type");
            entity.Property(e => e.Userid).HasColumnName("userid");
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

            entity.HasIndex(e => e.Userid, "MessengerInfo_userid_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("ARRAY['Discord'::text, 'Telegram'::text, 'Skype'::text, 'VK'::text]")
                .HasColumnName("type");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.User).WithOne(p => p.MessengerInfo)
                .HasForeignKey<MessengerInfo>(d => d.Userid)
                .HasConstraintName("MessengerInfo_userid_fkey");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RefreshTokens_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Expiresat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expiresat");
            entity.Property(e => e.Isexpired).HasColumnName("isexpired");
            entity.Property(e => e.Token).HasColumnName("token");

            entity.HasOne(d => d.TokenNavigation).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.Token)
                .HasConstraintName("RefreshTokens_token_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("Users_pkey");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("uid");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.Createdat).HasColumnName("createdat");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Ismentor)
                .HasDefaultValueSql("false")
                .HasColumnName("ismentor");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Passwordhash)
                .HasMaxLength(255)
                .HasColumnName("passwordhash");
            entity.Property(e => e.Post).HasColumnName("post");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Reviewscount).HasColumnName("reviewscount");
            entity.Property(e => e.Updatedat).HasColumnName("updatedat");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
