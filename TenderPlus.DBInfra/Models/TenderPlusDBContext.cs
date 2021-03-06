﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TenderPlus.DBInfra.Models
{
    public partial class TenderPlusDBContext : DbContext
    {
        public TenderPlusDBContext()
        {
        }

        public TenderPlusDBContext(DbContextOptions<TenderPlusDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bidding> Bidding { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Tender> Tender { get; set; }
        public virtual DbSet<TenderUsers> TenderUsers { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TenderPlusDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bidding>(entity =>
            {
                entity.HasKey(e => e.TenderId);

                entity.Property(e => e.TenderId).ValueGeneratedNever();

                entity.Property(e => e.EndTime).IsUnicode(false);

                entity.Property(e => e.FinalBid).IsUnicode(false);

                entity.Property(e => e.InititalBid).IsUnicode(false);

                entity.Property(e => e.StartTime).IsUnicode(false);

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.BiddingAssignee)
                    .HasForeignKey(d => d.AssigneeId)
                    .HasConstraintName("FK_Bidding_Tender");

                entity.HasOne(d => d.Reportee)
                    .WithMany(p => p.BiddingReportee)
                    .HasForeignKey(d => d.ReporteeId)
                    .HasConstraintName("FK_Bidding_User");

                entity.HasOne(d => d.Tender)
                    .WithOne(p => p.Bidding)
                    .HasForeignKey<Bidding>(d => d.TenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bidding_Tender1");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("IX_Login")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tender>(entity =>
            {
                entity.Property(e => e.Assignee)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CloseDate).IsUnicode(false);

                entity.Property(e => e.DemoImg).HasColumnType("image");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pin).IsUnicode(false);

                entity.Property(e => e.Reporter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TenderUsers>(entity =>
            {
                entity.Property(e => e.TenderId).HasColumnName("TenderID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Tender)
                    .WithMany(p => p.TenderUsers)
                    .HasForeignKey(d => d.TenderId)
                    .HasConstraintName("FK_TenderUsers_Tender1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TenderUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TenderUsers_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("IX_User")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aadhar)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar).HasColumnType("image");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.License)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PanId)
                    .IsRequired()
                    .HasColumnName("PanID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Login");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
