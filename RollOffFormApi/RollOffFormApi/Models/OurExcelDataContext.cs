using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RollOffFormApi.Models
{
    public partial class OurExcelDataContext : DbContext
    {
        public OurExcelDataContext()
        {
        }

        public OurExcelDataContext(DbContextOptions<OurExcelDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyDatum> MyData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN22004682\\SQLEXPRESS;Database=OurExcelData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<MyDatum>(entity =>
            {
                entity.HasKey(e => e.GlobalGroupId)
                    .HasName("PK__MyData__A8B3AC1A1BE7A2EA");

                entity.Property(e => e.GlobalGroupId).HasColumnName("Global Group ID");

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EmployeeNo).HasColumnName("Employee no");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Joining Date");

                entity.Property(e => e.LocalGrade)
                    .HasMaxLength(255)
                    .HasColumnName("Local Grade");

                entity.Property(e => e.MainClient)
                    .HasMaxLength(255)
                    .HasColumnName("Main Client");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NewGlobalPractice)
                    .HasMaxLength(255)
                    .HasColumnName("New Global Practice");

                entity.Property(e => e.OfficeCity)
                    .HasMaxLength(255)
                    .HasColumnName("Office City");

                entity.Property(e => e.PeopleManagerPerformanceReviewer)
                    .HasMaxLength(255)
                    .HasColumnName("People Manager (Performance Reviewer)");

                entity.Property(e => e.Practice).HasMaxLength(255);

                entity.Property(e => e.ProjectCode).HasColumnName("Project Code");

                entity.Property(e => e.ProjectEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Project End Date");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("Project Name");

                entity.Property(e => e.ProjectStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Project Start Date");

                entity.Property(e => e.PspName)
                    .HasMaxLength(255)
                    .HasColumnName("PSP Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
