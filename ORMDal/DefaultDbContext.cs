using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ORMDal
{
    public partial class DefaultDbContext : DbContext
    {
        public DefaultDbContext()
        {
        }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pacmanGame;Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Games>(entity =>
            //{
            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Games)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Games_UserId");
            //});
            //modelBuilder.Entity<Games>(entity =>
            //{
            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.Property(e => e.Score).IsRequired();

            //    entity.Property(e => e.GameDate).HasColumnType("datetime"); 

            //});
            modelBuilder.Entity<Games>(entity =>
            {
                entity.Property(e => e.GameDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Games_UserId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Login).IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
