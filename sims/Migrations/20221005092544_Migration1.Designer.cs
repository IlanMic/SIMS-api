﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sims.Data;

#nullable disable

namespace sims.Migrations
{
    [DbContext(typeof(SimsContext))]
    [Migration("20221005092544_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Sims.Models.DataFormat", b =>
                {
                    b.Property<int>("IdDataFormat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_data_format");

                    b.Property<string>("DataFormatName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("data_format_name");

                    b.HasKey("IdDataFormat")
                        .HasName("PRIMARY");

                    b.ToTable("data_format", (string)null);
                });

            modelBuilder.Entity("Sims.Models.DataLanguage", b =>
                {
                    b.Property<int>("IdDataLanguage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_data_language");

                    b.Property<string>("DataLanguageName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("data_language_name");

                    b.HasKey("IdDataLanguage")
                        .HasName("PRIMARY");

                    b.ToTable("data_language", (string)null);
                });

            modelBuilder.Entity("Sims.Models.DataOwner", b =>
                {
                    b.Property<long>("IdDataOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_data_owner");

                    b.Property<string>("DataOwnerName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("data_owner_name");

                    b.HasKey("IdDataOwner")
                        .HasName("PRIMARY");

                    b.ToTable("data_owner", (string)null);
                });

            modelBuilder.Entity("Sims.Models.DataTheme", b =>
                {
                    b.Property<int>("IdDataTheme")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_data_theme");

                    b.Property<string>("DataThemeName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("data_theme_name");

                    b.HasKey("IdDataTheme")
                        .HasName("PRIMARY");

                    b.ToTable("data_theme", (string)null);
                });

            modelBuilder.Entity("Sims.Models.DataUsage", b =>
                {
                    b.Property<long>("IdDataUsage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_data_usage");

                    b.Property<int>("DataFormatId")
                        .HasColumnType("int")
                        .HasColumnName("data_format_id");

                    b.Property<DateTime>("DateOfUsage")
                        .HasColumnType("datetime")
                        .HasColumnName("date_of_usage");

                    b.Property<sbyte>("IsDownloaded")
                        .HasColumnType("tinyint")
                        .HasColumnName("is_downloaded");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int")
                        .HasColumnName("language_id");

                    b.Property<long>("OpenDataId")
                        .HasColumnType("bigint")
                        .HasColumnName("open_data_id");

                    b.Property<long?>("UsedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("used_by");

                    b.HasKey("IdDataUsage")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DataFormatId" }, "index_data_format_id");

                    b.HasIndex(new[] { "LanguageId" }, "index_language_id");

                    b.HasIndex(new[] { "OpenDataId" }, "index_open_data_id");

                    b.HasIndex(new[] { "UsedBy" }, "index_used_by");

                    b.ToTable("data_usage", (string)null);
                });

            modelBuilder.Entity("Sims.Models.OpenDatum", b =>
                {
                    b.Property<long>("IdData")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_data");

                    b.Property<sbyte>("DataOpenLicense")
                        .HasColumnType("tinyint")
                        .HasColumnName("data_open_license");

                    b.Property<long>("DataOwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("data_owner_id");

                    b.Property<int>("DataThemeId")
                        .HasColumnType("int")
                        .HasColumnName("data_theme_id");

                    b.Property<string>("DataUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("data_url");

                    b.Property<int>("UpdateFrequencyId")
                        .HasColumnType("int")
                        .HasColumnName("update_frequency_id");

                    b.HasKey("IdData")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DataOwnerId" }, "index_data_owner_id");

                    b.HasIndex(new[] { "DataThemeId" }, "index_data_theme_id");

                    b.HasIndex(new[] { "UpdateFrequencyId" }, "index_update_frequency_id");

                    b.ToTable("open_data", (string)null);
                });

            modelBuilder.Entity("Sims.Models.Profession", b =>
                {
                    b.Property<int>("IdProfession")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_profession");

                    b.Property<string>("ProfessionName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("profession_name");

                    b.HasKey("IdProfession")
                        .HasName("PRIMARY");

                    b.ToTable("profession", (string)null);
                });

            modelBuilder.Entity("Sims.Models.ProfessionField", b =>
                {
                    b.Property<int>("IdProfessionField")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_profession_field");

                    b.Property<string>("ProfessionFieldName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("profession_field_name");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int")
                        .HasColumnName("profession_id");

                    b.HasKey("IdProfessionField")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProfessionId" }, "index_profession_id");

                    b.ToTable("profession_field", (string)null);
                });

            modelBuilder.Entity("Sims.Models.UpdateFrequency", b =>
                {
                    b.Property<int>("IdUpdateFrequency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_update_frequency");

                    b.Property<string>("UpdateFrequencyName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("update_frequency_name");

                    b.HasKey("IdUpdateFrequency")
                        .HasName("PRIMARY");

                    b.ToTable("update_frequency", (string)null);
                });

            modelBuilder.Entity("Sims.Models.User", b =>
                {
                    b.Property<long>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_user");

                    b.Property<string>("UserCompany")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("user_company");

                    b.Property<string>("UserMail")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("user_mail");

                    b.Property<string>("UserName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("user_name");

                    b.Property<byte[]>("UserPicture")
                        .HasColumnType("blob")
                        .HasColumnName("user_picture");

                    b.Property<int>("UserProfessionFieldId")
                        .HasColumnType("int")
                        .HasColumnName("user_profession_field_id");

                    b.Property<int>("UserProfessionId")
                        .HasColumnType("int")
                        .HasColumnName("user_profession_id");

                    b.HasKey("IdUser")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserProfessionFieldId" }, "index_user_profession_field_id");

                    b.HasIndex(new[] { "UserProfessionId" }, "index_user_profession_id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Sims.Models.DataUsage", b =>
                {
                    b.HasOne("Sims.Models.DataFormat", "DataFormat")
                        .WithMany("DataUsages")
                        .HasForeignKey("DataFormatId")
                        .IsRequired()
                        .HasConstraintName("data_usage_ibfk_2");

                    b.HasOne("Sims.Models.DataLanguage", "Language")
                        .WithMany("DataUsages")
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("data_usage_ibfk_3");

                    b.HasOne("Sims.Models.OpenDatum", "OpenData")
                        .WithMany("DataUsages")
                        .HasForeignKey("OpenDataId")
                        .IsRequired()
                        .HasConstraintName("data_usage_ibfk_1");

                    b.HasOne("Sims.Models.User", "UsedByNavigation")
                        .WithMany("DataUsages")
                        .HasForeignKey("UsedBy")
                        .HasConstraintName("data_usage_ibfk_4");

                    b.Navigation("DataFormat");

                    b.Navigation("Language");

                    b.Navigation("OpenData");

                    b.Navigation("UsedByNavigation");
                });

            modelBuilder.Entity("Sims.Models.OpenDatum", b =>
                {
                    b.HasOne("Sims.Models.DataOwner", "DataOwner")
                        .WithMany("OpenData")
                        .HasForeignKey("DataOwnerId")
                        .IsRequired()
                        .HasConstraintName("open_data_ibfk_1");

                    b.HasOne("Sims.Models.DataTheme", "DataTheme")
                        .WithMany("OpenData")
                        .HasForeignKey("DataThemeId")
                        .IsRequired()
                        .HasConstraintName("open_data_ibfk_3");

                    b.HasOne("Sims.Models.UpdateFrequency", "UpdateFrequency")
                        .WithMany("OpenData")
                        .HasForeignKey("UpdateFrequencyId")
                        .IsRequired()
                        .HasConstraintName("open_data_ibfk_2");

                    b.Navigation("DataOwner");

                    b.Navigation("DataTheme");

                    b.Navigation("UpdateFrequency");
                });

            modelBuilder.Entity("Sims.Models.ProfessionField", b =>
                {
                    b.HasOne("Sims.Models.Profession", "Profession")
                        .WithMany("ProfessionFields")
                        .HasForeignKey("ProfessionId")
                        .IsRequired()
                        .HasConstraintName("profession_field_ibfk_1");

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("Sims.Models.User", b =>
                {
                    b.HasOne("Sims.Models.ProfessionField", "UserProfessionField")
                        .WithMany("Users")
                        .HasForeignKey("UserProfessionFieldId")
                        .IsRequired()
                        .HasConstraintName("user_ibfk_2");

                    b.HasOne("Sims.Models.Profession", "UserProfession")
                        .WithMany("Users")
                        .HasForeignKey("UserProfessionId")
                        .IsRequired()
                        .HasConstraintName("user_ibfk_1");

                    b.Navigation("UserProfession");

                    b.Navigation("UserProfessionField");
                });

            modelBuilder.Entity("Sims.Models.DataFormat", b =>
                {
                    b.Navigation("DataUsages");
                });

            modelBuilder.Entity("Sims.Models.DataLanguage", b =>
                {
                    b.Navigation("DataUsages");
                });

            modelBuilder.Entity("Sims.Models.DataOwner", b =>
                {
                    b.Navigation("OpenData");
                });

            modelBuilder.Entity("Sims.Models.DataTheme", b =>
                {
                    b.Navigation("OpenData");
                });

            modelBuilder.Entity("Sims.Models.OpenDatum", b =>
                {
                    b.Navigation("DataUsages");
                });

            modelBuilder.Entity("Sims.Models.Profession", b =>
                {
                    b.Navigation("ProfessionFields");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Sims.Models.ProfessionField", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Sims.Models.UpdateFrequency", b =>
                {
                    b.Navigation("OpenData");
                });

            modelBuilder.Entity("Sims.Models.User", b =>
                {
                    b.Navigation("DataUsages");
                });
#pragma warning restore 612, 618
        }
    }
}
