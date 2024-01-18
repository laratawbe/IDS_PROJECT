using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IDS.Models;

public partial class ActClubContext : DbContext
{
    public ActClubContext()
    {
    }

    public ActClubContext(DbContextOptions<ActClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventGuide> EventGuides { get; set; }

    public virtual DbSet<EventMember> EventMembers { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-ST7ICV27;Database=ActClub;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4E853031BD1");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C8705C598ED7");

            entity.HasIndex(e => e.CategoryId, "IX_Events_CategoryID");

            entity.HasIndex(e => e.RelatedGuideId, "IX_Events_RelatedGuideID");

            entity.Property(e => e.EventId)
                .ValueGeneratedNever()
                .HasColumnName("EventID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.DateFrom).HasColumnType("date");
            entity.Property(e => e.DateTo).HasColumnType("date");
            entity.Property(e => e.Destination).HasMaxLength(255);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("(N'')");
            entity.Property(e => e.RelatedGuideId).HasColumnName("RelatedGuideID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

            entity.HasOne(d => d.Category).WithMany(p => p.Events)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Events__Category__4CA06362");

            entity.HasOne(d => d.RelatedGuide).WithMany(p => p.Events)
                .HasForeignKey(d => d.RelatedGuideId)
                .HasConstraintName("FK__Events__RelatedG__4D94879B");
        });

        modelBuilder.Entity<EventGuide>(entity =>
        {
            entity.HasKey(e => e.EventGuideId).HasName("PK__EventGui__6BD595D06F20C841");

            entity.HasIndex(e => e.EventId, "IX_EventGuides_EventID");

            entity.HasIndex(e => e.GuideId, "IX_EventGuides_GuideID");

            entity.Property(e => e.EventGuideId)
                .ValueGeneratedNever()
                .HasColumnName("EventGuideID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.GuideId).HasColumnName("GuideID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventGuides)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__EventGuid__Event__59FA5E80");

            entity.HasOne(d => d.Guide).WithMany(p => p.EventGuides)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("FK__EventGuid__Guide__5AEE82B9");
        });

        modelBuilder.Entity<EventMember>(entity =>
        {
            entity.HasKey(e => e.EventMemberId).HasName("PK__EventMem__0C810331BBF0DA00");

            entity.HasIndex(e => e.EventId, "IX_EventMembers_EventID");

            entity.HasIndex(e => e.MemberId, "IX_EventMembers_MemberID");

            entity.Property(e => e.EventMemberId)
                .ValueGeneratedNever()
                .HasColumnName("EventMemberID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventMembers)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__EventMemb__Event__5629CD9C");

            entity.HasOne(d => d.Member).WithMany(p => p.EventMembers)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__EventMemb__Membe__571DF1D5");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.GuideId).HasName("PK__Guides__E77EE03E09A73538");

            entity.HasIndex(e => e.Email, "UQ__Guides__A9D10534B09C50F7")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            entity.Property(e => e.GuideId)
                .ValueGeneratedNever()
                .HasColumnName("GuideID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Profession).HasMaxLength(255);
        });

        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.HasKey(e => e.LookupId).HasName("PK__Lookups__6D8B9C6B8A37D5CD");

            entity.Property(e => e.LookupId)
                .ValueGeneratedNever()
                .HasColumnName("LookupID");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B38BD85497A");

            entity.HasIndex(e => e.Email, "UQ__Members__A9D105341E52BC24")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("MemberID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EmergencyNumber).HasMaxLength(15);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.MobileNumber).HasMaxLength(15);
            entity.Property(e => e.Nationality).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Profession).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACBA0A055C");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053483873433")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
