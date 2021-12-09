using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskManagerPostgresDatabaseImplement.Models;

namespace TaskManagerPostgresDatabaseImplement
{
    /// <summary>
    /// Класс базы данных таск-менеджера
    /// </summary>
    public partial class TaskManagerDatabase : DbContext
    {
        public TaskManagerDatabase() { }
        
        public TaskManagerDatabase(DbContextOptions<TaskManagerDatabase> options) : base(options) {}

        public virtual DbSet<Employer> Employers { get; set; }

        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<Stage> Stages { get; set; }

        public virtual DbSet<StageDeveloper> StageDeveloper { get; set; }

        public virtual DbSet<Developer> Developers { get; set; }

        public virtual DbSet<DeveloperProgramLanguage> DeveloperProgramLanguage { get; set; }

        public virtual DbSet<ProgramLanguage> ProgramLanguages { get; set; }


        /// <summary>
        /// Настраиваем сервер базы данных
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {              
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TaskManager;User Id=swed19;Password=password");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("employers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullNameOfEmployer).IsRequired().HasColumnName("fullnameofemployer").HasMaxLength(255);

                entity.Property(e => e.EmployerLogin).IsRequired().HasColumnName("employerlogin");

                entity.Property(e => e.EmployerPassword).IsRequired().HasColumnName("employerpassword");

                entity.Property(e => e.isDeleted).HasColumnName("isdeleted");

            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TaskName).IsRequired().HasColumnName("taskname").HasMaxLength(255);

                entity.Property(e => e.TaskStartDate).IsRequired().HasColumnName("taskstartdate").HasColumnType("date");

                entity.Property(e => e.TaskFinishDate).HasColumnName("taskfinishdate").HasColumnType("date");

                entity.Property(e => e.isDeleted).HasColumnName("isdeleted");

                entity.Property(e => e.EmployerId).HasColumnName("employerid");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employerid_fkey");

            });

            modelBuilder.Entity<Stage>(entity =>
            {
                entity.ToTable("stages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StageDescription).IsRequired().HasColumnName("stagedescription").HasMaxLength(255);

                entity.Property(e => e.StageStartDate).IsRequired().HasColumnName("stagestartdate").HasColumnType("date");

                entity.Property(e => e.StageFinishDate).HasColumnName("stagefinishdate").HasColumnType("date");

                entity.Property(e => e.isComplited).HasColumnName("iscomplited");

                entity.Property(e => e.isDeleted).HasColumnName("isdeleted");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("taskid_fkey");
             
            });

            modelBuilder.Entity<StageDeveloper>(entity =>
            {
                entity.HasKey(e => new { e.StageId, e.DeveloperId })
                    .HasName("stage_developer_pkey");

                entity.ToTable("stage_developer");

                entity.Property(e => e.StageId).HasColumnName("stageid");

                entity.Property(e => e.DeveloperId).HasColumnName("developerid");

                entity.HasOne(d => d.Stage)
                    .WithMany(p => p.StageDevelopers)
                    .HasForeignKey(d => d.StageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stageid_fkey");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.DeveloperStages)
                    .HasForeignKey(d => d.DeveloperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("developerid_fkey");
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.ToTable("developers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullNameOfDeveloper).IsRequired().HasColumnName("fullnameofdeveloper").HasMaxLength(255);

                entity.Property(e => e.DeveloperPosition).IsRequired().HasColumnName("developerposition").HasMaxLength(255);

                entity.Property(e => e.WorkExperience).IsRequired().HasColumnName("workexperience");

                entity.Property(e => e.isDeleted).HasColumnName("isdeleted");

                entity.Property(e => e.isDeleted).HasColumnName("isdeleted");

            });

            modelBuilder.Entity<DeveloperProgramLanguage>(entity =>
            {
                entity.HasKey(e => new { e.DeveloperId, e.ProgramLanguageId })
                    .HasName("developer_programlanguage_pkey");

                entity.ToTable("developer_programlanguage");

                entity.Property(e => e.DeveloperId).HasColumnName("developerid");

                entity.Property(e => e.ProgramLanguageId).HasColumnName("programlanguageid");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.DeveloperProgramLanguages)
                    .HasForeignKey(d => d.DeveloperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("developerid_fkey");

                entity.HasOne(d => d.ProgramLanguage)
                    .WithMany(p => p.ProgramLanguageDevelopers)
                    .HasForeignKey(d => d.ProgramLanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("programlanguageid_fkey");
            });

            modelBuilder.Entity<ProgramLanguage>(entity =>
            {
                entity.ToTable("programlanguages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageName).IsRequired().HasColumnName("languagename").HasMaxLength(255);

                entity.Property(e => e.LanguageDescription).HasColumnName("languagedescription").HasMaxLength(255);
            });

            modelBuilder.HasSequence("employerid");

            modelBuilder.HasSequence("taskid");

            modelBuilder.HasSequence("stageid");

            modelBuilder.HasSequence("developerid");

            modelBuilder.HasSequence("programlanguageid");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
