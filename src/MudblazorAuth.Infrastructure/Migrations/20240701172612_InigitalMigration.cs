using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MudblazorAuth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InigitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_private = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_profile = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_accounts_profiles_id_profile",
                        column: x => x.id_profile,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profilepages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_profile = table.Column<long>(type: "bigint", nullable: false),
                    id_page = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profilepages", x => x.id);
                    table.ForeignKey(
                        name: "fk_profilepages_pages_id_page",
                        column: x => x.id_page,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_profilepages_profiles_id_profile",
                        column: x => x.id_profile,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "pages",
                columns: new[] { "id", "is_private", "url" },
                values: new object[,]
                {
                    { 1L, false, "/SignIn" },
                    { 2L, false, "/Register" },
                    { 3L, true, "/Home" },
                    { 4L, true, "/Counter" },
                    { 5L, true, "/Weather" },
                    { 6L, true, "/ProfilePermissionsPage" },
                    { 7L, true, "/Users" },
                    { 8L, true, "/AccessDenied" }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "description" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "User" }
                });

            migrationBuilder.InsertData(
                table: "profilepages",
                columns: new[] { "id", "id_page", "id_profile" },
                values: new object[,]
                {
                    { 1L, 3L, 1L },
                    { 2L, 4L, 1L },
                    { 3L, 5L, 1L },
                    { 4L, 6L, 1L },
                    { 5L, 7L, 1L },
                    { 6L, 8L, 1L },
                    { 7L, 3L, 2L },
                    { 8L, 4L, 2L },
                    { 9L, 5L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "ix_accounts_id_profile",
                table: "accounts",
                column: "id_profile");

            migrationBuilder.CreateIndex(
                name: "ix_profilepages_id_page",
                table: "profilepages",
                column: "id_page");

            migrationBuilder.CreateIndex(
                name: "ix_profilepages_id_profile",
                table: "profilepages",
                column: "id_profile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "profilepages");

            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "profiles");
        }
    }
}
