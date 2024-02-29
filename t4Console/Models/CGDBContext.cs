using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace t4Console.Models;

public partial class CGDBContext : DbContext
{
    public CGDBContext()
    {
    }

    public CGDBContext(DbContextOptions<CGDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Domain> Domains { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=new_schema;uid=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Domain>(entity =>
        {
            entity.HasKey(e => e.DomainId).HasName("PRIMARY");

            entity.ToTable("domain");

            entity.HasIndex(e => e.FieldId, "fieldId_idx");

            entity.HasIndex(e => e.PageId, "pageId_idx");

            entity.Property(e => e.DomainId)
                .ValueGeneratedNever()
                .HasColumnName("domainId");
            entity.Property(e => e.AttributeValue)
                .HasMaxLength(100)
                .HasColumnName("attributeValue");
            entity.Property(e => e.DomainName)
                .HasMaxLength(45)
                .HasColumnName("domainName");
            entity.Property(e => e.DomainSeq).HasColumnName("domainSeq");
            entity.Property(e => e.FieldId).HasColumnName("fieldId");
            entity.Property(e => e.PageId).HasColumnName("pageId");

            entity.HasOne(d => d.Field).WithMany(p => p.Domains)
                .HasForeignKey(d => d.FieldId)
                .HasConstraintName("fieldIdx");

            entity.HasOne(d => d.Page).WithMany(p => p.Domains)
                .HasForeignKey(d => d.PageId)
                .HasConstraintName("pageIdx1");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.FieldId).HasName("PRIMARY");

            entity.ToTable("field");

            entity.HasIndex(e => e.PageId, "pageIdx_idx");

            entity.Property(e => e.FieldId)
                .ValueGeneratedNever()
                .HasColumnName("fieldId");
            entity.Property(e => e.DataSize).HasColumnName("dataSize");
            entity.Property(e => e.DispCondition)
                .HasMaxLength(45)
                .HasColumnName("dispCondition");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(45)
                .HasColumnName("displayName");
            entity.Property(e => e.FieldDescription)
                .HasMaxLength(45)
                .HasColumnName("fieldDescription");
            entity.Property(e => e.FieldName)
                .HasMaxLength(45)
                .HasColumnName("fieldName");
            entity.Property(e => e.FieldType)
                .HasMaxLength(45)
                .HasColumnName("fieldType");
            entity.Property(e => e.MaxSize)
                .HasMaxLength(25)
                .HasColumnName("maxSize");
            entity.Property(e => e.MinSize)
                .HasMaxLength(25)
                .HasColumnName("minSize");
            entity.Property(e => e.PageId).HasColumnName("pageId");
            entity.Property(e => e.ReqCondition)
                .HasMaxLength(45)
                .HasColumnName("reqCondition");
            entity.Property(e => e.Required)
                .HasDefaultValueSql("'0'")
                .HasColumnName("required");
            entity.Property(e => e.Sequence).HasColumnName("sequence");

            entity.HasOne(d => d.Page).WithMany(p => p.Fields)
                .HasForeignKey(d => d.PageId)
                .HasConstraintName("pageIdx");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PRIMARY");

            entity.ToTable("pages");

            entity.Property(e => e.PageId).HasColumnName("pageId");
            entity.Property(e => e.PageDescription)
                .HasMaxLength(45)
                .HasColumnName("pageDescription");
            entity.Property(e => e.PageIdentifier)
                .HasMaxLength(45)
                .HasColumnName("pageIdentifier");
            entity.Property(e => e.PageTitle)
                .HasMaxLength(45)
                .HasColumnName("pageTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
