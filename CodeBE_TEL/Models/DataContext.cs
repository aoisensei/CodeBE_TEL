using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeBE_TEL.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnswerDAO> Answers { get; set; }

    public virtual DbSet<BoardDAO> Boards { get; set; }

    public virtual DbSet<CardDAO> Cards { get; set; }

    public virtual DbSet<ClassEventDAO> ClassEvents { get; set; }

    public virtual DbSet<ClassroomDAO> Classrooms { get; set; }

    public virtual DbSet<CommentDAO> Comments { get; set; }

    public virtual DbSet<JobDAO> Jobs { get; set; }

    public virtual DbSet<QuestionDAO> Questions { get; set; }

    public virtual DbSet<TodoDAO> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:dbconn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnswerDAO>(entity =>
        {
            entity.ToTable("Answer");

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answer_Question");
        });

        modelBuilder.Entity<BoardDAO>(entity =>
        {
            entity.ToTable("Board");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CardDAO>(entity =>
        {
            entity.ToTable("Card");

            entity.HasIndex(e => e.BoardId, "IX_Card_BoardId");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Board).WithMany(p => p.Cards)
                .HasForeignKey(d => d.BoardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_Board");
        });

        modelBuilder.Entity<ClassEventDAO>(entity =>
        {
            entity.ToTable("ClassEvent");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EndAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Classroom).WithMany(p => p.ClassEvents)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClassEvent_Classroom");
        });

        modelBuilder.Entity<ClassroomDAO>(entity =>
        {
            entity.ToTable("Classroom");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CommentDAO>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsFixedLength();

            entity.HasOne(d => d.ClassEvent).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ClassEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_ClassEvent");
        });

        modelBuilder.Entity<JobDAO>(entity =>
        {
            entity.ToTable("Job");

            entity.HasIndex(e => e.CardId, "IX_Job_CardId");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PlanTime).HasMaxLength(50);

            entity.HasOne(d => d.Card).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Job_Card");
        });

        modelBuilder.Entity<QuestionDAO>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.CorrectAnswer).HasMaxLength(5);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Instruction).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.StudentAnswer).HasMaxLength(5);

            entity.HasOne(d => d.ClassEvent).WithMany(p => p.Questions)
                .HasForeignKey(d => d.ClassEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_ClassEvent");
        });

        modelBuilder.Entity<TodoDAO>(entity =>
        {
            entity.ToTable("Todo");

            entity.HasIndex(e => e.JobId, "IX_Todo_JobId");

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.Job).WithMany(p => p.Todos)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Todo_Job");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
