using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lektion_med_Petter_REPETION.Models;

public partial class MemberRegistryContext : DbContext
{
    public MemberRegistryContext()
    {
    }

    public MemberRegistryContext(DbContextOptions<MemberRegistryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityParticipation> ActivityParticipations { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=MemberRegistry;Integrated Security=True; Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Activiti__45F4A7F1AB36019A");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ActivityParticipation>(entity =>
        {
            entity.HasKey(e => e.ParticipationId).HasName("PK__Activity__4EA270804C44F336");

            entity.ToTable("ActivityParticipation");

            entity.HasIndex(e => new { e.MemberId, e.ActivityId }, "UQ_Participation").IsUnique();

            entity.Property(e => e.ParticipationId).HasColumnName("ParticipationID");
            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.ActivityParticipations)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__ActivityP__Activ__4222D4EF");

            entity.HasOne(d => d.Member).WithMany(p => p.ActivityParticipations)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__ActivityP__Membe__412EB0B6");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B383CA9E461");

            entity.HasIndex(e => e.Email, "UQ__Members__A9D105343E22B763").IsUnique();

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.AdressId).HasColumnName("Adress_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__Membersh__92A78599D5F228DA");

            entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.MembershipType).HasMaxLength(50);

            entity.HasOne(d => d.Member).WithMany(p => p.Memberships)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Membershi__Membe__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
