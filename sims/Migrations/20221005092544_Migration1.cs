using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sims.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "data_format",
                columns: table => new
                {
                    id_data_format = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_format_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_data_format);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "data_language",
                columns: table => new
                {
                    id_data_language = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_language_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_data_language);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "data_owner",
                columns: table => new
                {
                    id_data_owner = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_owner_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_data_owner);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "data_theme",
                columns: table => new
                {
                    id_data_theme = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_theme_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_data_theme);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "update_frequency",
                columns: table => new
                {
                    id_update_frequency = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    update_frequency_name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_update_frequency);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "open_data",
                columns: table => new
                {
                    id_data = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_url = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_open_license = table.Column<sbyte>(type: "tinyint", nullable: false),
                    data_owner_id = table.Column<long>(type: "bigint", nullable: false),
                    update_frequency_id = table.Column<int>(type: "int", nullable: false),
                    data_theme_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_data);
                    table.ForeignKey(
                        name: "open_data_ibfk_1",
                        column: x => x.data_owner_id,
                        principalTable: "data_owner",
                        principalColumn: "id_data_owner");
                    table.ForeignKey(
                        name: "open_data_ibfk_2",
                        column: x => x.update_frequency_id,
                        principalTable: "update_frequency",
                        principalColumn: "id_update_frequency");
                    table.ForeignKey(
                        name: "open_data_ibfk_3",
                        column: x => x.data_theme_id,
                        principalTable: "data_theme",
                        principalColumn: "id_data_theme");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "data_usage",
                columns: table => new
                {
                    id_data_usage = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    open_data_id = table.Column<long>(type: "bigint", nullable: false),
                    date_of_usage = table.Column<DateTime>(type: "datetime", nullable: false),
                    data_format_id = table.Column<int>(type: "int", nullable: false),
                    language_id = table.Column<int>(type: "int", nullable: false),
                    is_downloaded = table.Column<sbyte>(type: "tinyint", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_data_usage);
                    table.ForeignKey(
                        name: "data_usage_ibfk_1",
                        column: x => x.open_data_id,
                        principalTable: "open_data",
                        principalColumn: "id_data");
                    table.ForeignKey(
                        name: "data_usage_ibfk_2",
                        column: x => x.data_format_id,
                        principalTable: "data_format",
                        principalColumn: "id_data_format");
                    table.ForeignKey(
                        name: "data_usage_ibfk_3",
                        column: x => x.language_id,
                        principalTable: "data_language",
                        principalColumn: "id_data_language");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "index_data_format_id",
                table: "data_usage",
                column: "data_format_id");

            migrationBuilder.CreateIndex(
                name: "index_language_id",
                table: "data_usage",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "index_open_data_id",
                table: "data_usage",
                column: "open_data_id");

            migrationBuilder.CreateIndex(
                name: "index_data_owner_id",
                table: "open_data",
                column: "data_owner_id");

            migrationBuilder.CreateIndex(
                name: "index_data_theme_id",
                table: "open_data",
                column: "data_theme_id");

            migrationBuilder.CreateIndex(
                name: "index_update_frequency_id",
                table: "open_data",
                column: "update_frequency_id");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "data_usage");

            migrationBuilder.DropTable(
                name: "open_data");

            migrationBuilder.DropTable(
                name: "data_format");

            migrationBuilder.DropTable(
                name: "data_language");


            migrationBuilder.DropTable(
                name: "data_owner");

            migrationBuilder.DropTable(
                name: "update_frequency");

            migrationBuilder.DropTable(
                name: "data_theme");
        }
    }
}
