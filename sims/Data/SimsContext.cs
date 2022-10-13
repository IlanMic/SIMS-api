﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sims.Models;

namespace Sims.Data
{
    public partial class SimsContext : DbContext
    {
        public SimsContext()
        {
        }

        public SimsContext(DbContextOptions<SimsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataFormat> DataFormats { get; set; } = null!;
        public virtual DbSet<DataLanguage> DataLanguages { get; set; } = null!;
        public virtual DbSet<DataOwner> DataOwners { get; set; } = null!;
        public virtual DbSet<DataTheme> DataThemes { get; set; } = null!;
        public virtual DbSet<DataUsage> DataUsages { get; set; } = null!;
        public virtual DbSet<OpenDatum> OpenData { get; set; } = null!;
        public virtual DbSet<UpdateFrequency> UpdateFrequencies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<DataFormat>(entity =>
            {
                entity.HasKey(e => e.IdDataFormat)
                    .HasName("PRIMARY");

                entity.ToTable("data_format");

                entity.Property(e => e.IdDataFormat).HasColumnName("id_data_format");

                entity.Property(e => e.DataFormatName)
                    .HasMaxLength(250)
                    .HasColumnName("data_format_name");
            });

            modelBuilder.Entity<DataLanguage>(entity =>
            {
                entity.HasKey(e => e.IdDataLanguage)
                    .HasName("PRIMARY");

                entity.ToTable("data_language");

                entity.Property(e => e.IdDataLanguage).HasColumnName("id_data_language");

                entity.Property(e => e.DataLanguageName)
                    .HasMaxLength(250)
                    .HasColumnName("data_language_name");
            });

            modelBuilder.Entity<DataOwner>(entity =>
            {
                entity.HasKey(e => e.IdDataOwner)
                    .HasName("PRIMARY");

                entity.ToTable("data_owner");

                entity.Property(e => e.IdDataOwner).HasColumnName("id_data_owner");

                entity.Property(e => e.DataOwnerName)
                    .HasMaxLength(250)
                    .HasColumnName("data_owner_name");
            });

            modelBuilder.Entity<DataTheme>(entity =>
            {
                entity.HasKey(e => e.IdDataTheme)
                    .HasName("PRIMARY");

                entity.ToTable("data_theme");

                entity.Property(e => e.IdDataTheme).HasColumnName("id_data_theme");

                entity.Property(e => e.DataThemeName)
                    .HasMaxLength(250)
                    .HasColumnName("data_theme_name");
            });

            modelBuilder.Entity<DataUsage>(entity =>
            {
                entity.HasKey(e => e.IdDataUsage)
                    .HasName("PRIMARY");

                entity.ToTable("data_usage");

                entity.HasIndex(e => e.DataFormatId, "index_data_format_id");

                entity.HasIndex(e => e.LanguageId, "index_language_id");

                entity.HasIndex(e => e.OpenDataId, "index_open_data_id");

                entity.Property(e => e.IdDataUsage).HasColumnName("id_data_usage");

                entity.Property(e => e.DataFormatId).HasColumnName("data_format_id");

                entity.Property(e => e.DateOfUsage)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_usage");

                entity.Property(e => e.IsDownloaded).HasColumnName("is_downloaded");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.OpenDataId).HasColumnName("open_data_id");


                entity.HasOne(d => d.DataFormat)
                    .WithMany(p => p.DataUsages)
                    .HasForeignKey(d => d.DataFormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("data_usage_ibfk_2");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DataUsages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("data_usage_ibfk_3");

                entity.HasOne(d => d.OpenData)
                    .WithMany(p => p.DataUsages)
                    .HasForeignKey(d => d.OpenDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("data_usage_ibfk_1");

            });

            modelBuilder.Entity<OpenDatum>(entity =>
            {
                entity.HasKey(e => e.IdData)
                    .HasName("PRIMARY");

                entity.ToTable("open_data");

                entity.HasIndex(e => e.DataOwnerId, "index_data_owner_id");

                entity.HasIndex(e => e.DataThemeId, "index_data_theme_id");

                entity.HasIndex(e => e.UpdateFrequencyId, "index_update_frequency_id");

                entity.Property(e => e.IdData).HasColumnName("id_data");

                entity.Property(e => e.DataOpenLicense).HasColumnName("data_open_license");

                entity.Property(e => e.DataOwnerId).HasColumnName("data_owner_id");

                entity.Property(e => e.DataThemeId).HasColumnName("data_theme_id");

                entity.Property(e => e.DataUrl)
                    .HasMaxLength(250)
                    .HasColumnName("data_url");

                entity.Property(e => e.UpdateFrequencyId).HasColumnName("update_frequency_id");

                entity.HasOne(d => d.DataOwner)
                    .WithMany(p => p.OpenData)
                    .HasForeignKey(d => d.DataOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("open_data_ibfk_1");

                entity.HasOne(d => d.DataTheme)
                    .WithMany(p => p.OpenData)
                    .HasForeignKey(d => d.DataThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("open_data_ibfk_3");

                entity.HasOne(d => d.UpdateFrequency)
                    .WithMany(p => p.OpenData)
                    .HasForeignKey(d => d.UpdateFrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("open_data_ibfk_2");
            });


            modelBuilder.Entity<UpdateFrequency>(entity =>
            {
                entity.HasKey(e => e.IdUpdateFrequency)
                    .HasName("PRIMARY");

                entity.ToTable("update_frequency");

                entity.Property(e => e.IdUpdateFrequency).HasColumnName("id_update_frequency");

                entity.Property(e => e.UpdateFrequencyName)
                    .HasMaxLength(250)
                    .HasColumnName("update_frequency_name");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
