using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace FindWorker.Entity.Models
{
    public partial class FindWorkersTezContext : DbContext
    {
        public FindWorkersTezContext()
        {
        }

        public FindWorkersTezContext(DbContextOptions<FindWorkersTezContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advert> Advert { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Cvdata> Cvdata { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Hobby> Hobby { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WorkExperience> WorkExperience { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:findworkersdb.database.windows.net;Database=FindWorkersDB;User ID =adminazure; Password =FindWorker8 ; Trusted_Connection = False;Encrypt = True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>(entity =>
            {
                entity.Property(e => e.AdvertName).HasMaxLength(75);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.SchoolType).HasMaxLength(50);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyEmail)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Decription).HasColumnType("text");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Cvdata>(entity =>
            {
                entity.ToTable("CVData");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CvName).HasMaxLength(75);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

               // entity.Property(e => e.DocumentDate).HasMaxLength(10);

                entity.Property(e => e.DocumentationName).HasMaxLength(75);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(75);

                entity.Property(e => e.GruadetDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SchoolName).HasMaxLength(100);

                entity.Property(e => e.SchoolType).HasMaxLength(50);
            });

            modelBuilder.Entity<Hobby>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.HobbiesName).HasMaxLength(75);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedUser).HasMaxLength(10);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LanguageName).HasMaxLength(50);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Message1)
                    .HasColumnName("Message")
                    .HasColumnType("text");

                entity.Property(e => e.MessageDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectName).HasMaxLength(100);
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceEmail).HasMaxLength(75);

                entity.Property(e => e.ReferenceName).HasMaxLength(75);

                entity.Property(e => e.ReferencePhone).HasMaxLength(50);

                entity.Property(e => e.ReferencePosition).HasMaxLength(75);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleType).HasMaxLength(50);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SkillLevel).HasMaxLength(5);

                entity.Property(e => e.SkillName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(75);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("Phone_Number")
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePhoto).HasColumnName("Profile_Photo");

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(150);
            });

            modelBuilder.Entity<WorkExperience>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(75);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Position).HasMaxLength(75);

                entity.Property(e => e.WorkFinishTime).HasMaxLength(10);
                entity.Property(e => e.WorkStartTime).HasMaxLength(10);
            });
        }
    }
}
