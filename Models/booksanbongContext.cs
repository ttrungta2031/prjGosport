using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gosport.Models
{
    public partial class booksanbongContext : DbContext
    {
        public booksanbongContext()
        {
        }

        public booksanbongContext(DbContextOptions<booksanbongContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Booksan> Booksans { get; set; }
        public virtual DbSet<Sanbong> Sanbongs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("workstation id=booksanbong.mssql.somee.com;packet size=4096;user id=booksanbong_SQLLogin_1;pwd=1ww7x4caq1;data source=booksanbong.mssql.somee.com;persist security info=False;initial catalog=booksanbong");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.CreateDay).HasColumnType("date");

                entity.Property(e => e.TimeEnd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStart)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Booking_User");

                entity.HasOne(d => d.Sanbong)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Sanbongid)
                    .HasConstraintName("FK_Booking_sanbong");
            });

            modelBuilder.Entity<Booksan>(entity =>
            {
                entity.ToTable("Booksan");

                entity.Property(e => e.TimeEnd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStart)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Booksans)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_Booksan_Booking");

                entity.HasOne(d => d.Sanbong)
                    .WithMany(p => p.Booksans)
                    .HasForeignKey(d => d.SanbongId)
                    .HasConstraintName("FK_Booksan_sanbong");
            });

            modelBuilder.Entity<Sanbong>(entity =>
            {
                entity.ToTable("sanbong");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.CreateDay).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Scope)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UrlImage).IsUnicode(false);

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Sanbongs)
                    .HasForeignKey(d => d.Owner)
                    .HasConstraintName("FK_sanbong_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
