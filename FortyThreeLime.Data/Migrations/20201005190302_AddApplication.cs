using Microsoft.EntityFrameworkCore.Migrations;

namespace FortyThreeLime.Data.Migrations
{
    public partial class AddApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    AppType = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    AppToken = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "AppName", "AppToken", "AppType", "Description" },
                values: new object[] { 1, "FortyThreeLime.Web", "a4Y0281F95Gth40GJe9q09swk3XK", 1, "Web Portal for Solution" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "AppName", "AppToken", "AppType", "Description" },
                values: new object[] { 2, "FortyThreeLime.API", "GeC34y742m6oC9wBcs634hM3V8R1", 0, "Web API for Solution" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "AppName", "AppToken", "AppType", "Description" },
                values: new object[] { 3, "FortyThreeLime.Mobile.Android", "C4LX502J3b6ioqJ7Es86ulm5X3p9", 2, "Android Application for Solution" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppName",
                table: "Applications",
                column: "AppName");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AppToken",
                table: "Applications",
                column: "AppToken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
