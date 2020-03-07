using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevelopmentUtilitiesRESTful.Models
{
    public partial class DevelopmentUtilitiesV2Context : DbContext
    {
        public DevelopmentUtilitiesV2Context()
        {
        }

        public DevelopmentUtilitiesV2Context(DbContextOptions<DevelopmentUtilitiesV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CodeBlocksV2> CodeBlocks { get; set; }
        public virtual DbSet<CommandsV2> Commands { get; set; }
        public virtual DbSet<ExercisesV2> Exercises { get; set; }
        public virtual DbSet<ProblemsV2> Problems { get; set; }
        public virtual DbSet<ResourcesV2> Resources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GIV9OCS\\MSSQLSERVER01;Database=DevelopmentUtilitiesV2;User ID=RestfulAPIUser;Password=Password_21600681;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CodeBlocksV2>(entity =>
            {
                entity.Property(e => e.Block).IsRequired();

                entity.Property(e => e.Langue)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<CommandsV2>(entity =>
            {
                entity.Property(e => e.Command).IsRequired();

                entity.Property(e => e.ConsoleType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ExercisesV2>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Exercise__3214EC0653CED8CB")
                    .IsUnique();

                entity.Property(e => e.Exercise).IsRequired();

                entity.Property(e => e.ExerciseLevel).HasMaxLength(50);

                entity.Property(e => e.ExpectedSolution).HasMaxLength(50);

                entity.Property(e => e.Langues).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.ProjectType).HasMaxLength(50);

                entity.Property(e => e.VarableData).HasMaxLength(50);
            });

            modelBuilder.Entity<ProblemsV2>(entity =>
            {
                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<ResourcesV2>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("UQ__Resource__2CB664DC304E151E")
                    .IsUnique();

                entity.Property(e => e.Langues).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
