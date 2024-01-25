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

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventGuide> EventGuides { get; set; }

    public virtual DbSet<EventMember> EventMembers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=ActClub;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C8701954088D");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DateFrom).HasColumnType("date");
            entity.Property(e => e.DateTo).HasColumnType("date");
            entity.Property(e => e.Destination).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<EventGuide>(entity =>
        {
            entity.HasKey(e => e.EventGuideId).HasName("PK__EventGui__6BD595D024DACBB2");

            entity.Property(e => e.EventGuideId).HasColumnName("EventGuideID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.GuideId).HasColumnName("GuideID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventGuides)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__EventGuid__Event__787EE5A0");

            entity.HasOne(d => d.Guide).WithMany(p => p.EventGuides)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("FK__EventGuid__Guide__797309D9");
        });

        modelBuilder.Entity<EventMember>(entity =>
        {
            entity.HasKey(e => e.EventMemberId).HasName("PK__EventMem__0C810331FF26C45E");

            entity.Property(e => e.EventMemberId).HasColumnName("EventMemberID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventMembers)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__EventMemb__Event__74AE54BC");

            entity.HasOne(d => d.Member).WithMany(p => p.EventMembers)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__EventMemb__Membe__75A278F5");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC40E012EB");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053400C43E79").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.UserName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
