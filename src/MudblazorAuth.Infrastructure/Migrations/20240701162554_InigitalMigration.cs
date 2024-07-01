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
                    url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    isprivate = table.Column<bool>(type: "bit", nullable: false)
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
                    idprofile = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_accounts_profiles_idprofile",
                        column: x => x.idprofile,
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
                    idprofile = table.Column<long>(type: "bigint", nullable: false),
                    idpage = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profilepages", x => x.id);
                    table.ForeignKey(
                        name: "fk_profilepages_pages_idpage",
                        column: x => x.idpage,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_profilepages_profiles_idprofile",
                        column: x => x.idprofile,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "pages",
                columns: new[] { "id", "isprivate", "url" },
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
                columns: new[] { "id", "idpage", "idprofile" },
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
                name: "ix_accounts_idprofile",
                table: "accounts",
                column: "idprofile");

            migrationBuilder.CreateIndex(
                name: "ix_profilepages_idpage",
                table: "profilepages",
                column: "idpage");

            migrationBuilder.CreateIndex(
                name: "ix_profilepages_idprofile",
                table: "profilepages",
                column: "idprofile");
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
