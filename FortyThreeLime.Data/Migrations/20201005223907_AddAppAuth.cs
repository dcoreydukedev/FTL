using Microsoft.EntityFrameworkCore.Migrations;

namespace FortyThreeLime.Data.Migrations
{
    public partial class AddAppAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAuth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoginToken = table.Column<string>(type: "TEXT", nullable: true),
                    LoginTokenActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ApplicationId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginTime = table.Column<string>(type: "TEXT", nullable: true),
                    LoginExpires = table.Column<string>(type: "TEXT", nullable: true),
                    LogoutTime = table.Column<string>(type: "TEXT", nullable: true),
                    UserId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAuth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAuth_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppAuth_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppAuth_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAuth_ApplicationId",
                table: "AppAuth",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAuth_RoleId",
                table: "AppAuth",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAuth_UserId1",
                table: "AppAuth",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAuth");
        }
    }
}
