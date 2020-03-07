using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasicCSharpRESTful.Models
{
    public partial class DevelopmentUtilitiesContext : DbContext
    {
        public DevelopmentUtilitiesContext()
        {
        }

        public DevelopmentUtilitiesContext(DbContextOptions<DevelopmentUtilitiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommandsV1> Commands { get; set; }
        public virtual DbSet<ExercisesV1> Exercises { get; set; }
        public virtual DbSet<ProblemsV1> Problems { get; set; }
        public virtual DbSet<ResourcesV1> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GIV9OCS\\MSSQLSERVER01;User ID=RestfulAPIUser;Password=Password_21600681;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CommandsV1>(entity =>
            {
                entity.Property(e => e.Command)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ConsoleType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExercisesV1>(entity =>
            {
                entity.HasIndex(e => e.Exercise)
                    .HasName("UQ__Exercise__051A1072C65BE6D9")
                    .IsUnique();

                entity.Property(e => e.Exercise)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ExerciseLevel).HasMaxLength(50);

                entity.Property(e => e.ExpectedSolution).HasMaxLength(250);

                entity.Property(e => e.Langues).HasMaxLength(250);

                entity.Property(e => e.ProjectType).HasMaxLength(250);

                entity.Property(e => e.Solution).HasMaxLength(250);

                entity.Property(e => e.VarableData).HasMaxLength(50);
            });

            modelBuilder.Entity<ProblemsV1>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<ResourcesV1>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("UQ__Resource__2CB664DC1CAB4FC0")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Langues).HasMaxLength(50);

                entity.Property(e => e.Link).HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
