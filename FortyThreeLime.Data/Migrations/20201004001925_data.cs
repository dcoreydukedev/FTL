using Microsoft.EntityFrameworkCore.Migrations;

namespace FortyThreeLime.Data.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ButtonCommandCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonCommandCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 56, nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsOnline = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ButtonCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommandId = table.Column<int>(type: "INTEGER", nullable: false),
                    Command = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonCommands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ButtonCommands_ButtonCommandCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ButtonCommandCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommandLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 4, nullable: true),
                    CommandId = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<long>(type: "INTEGER", nullable: false),
                    Latitude = table.Column<string>(type: "TEXT", nullable: true),
                    Longitude = table.Column<string>(type: "TEXT", nullable: true),
                    UserId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommandLog_ButtonCommands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "ButtonCommands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandLog_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ButtonCommandCategories",
                columns: new[] { "Id", "Category", "Description" },
                values: new object[] { 1, "WorkDay", "Buttons pertaining to the work day as a whole." });

            migrationBuilder.InsertData(
                table: "ButtonCommandCategories",
                columns: new[] { "Id", "Category", "Description" },
                values: new object[] { 2, "MainTask", "Buttons non the main screen pertaining to the main tasks performed during the workday." });

            migrationBuilder.InsertData(
                table: "ButtonCommandCategories",
                columns: new[] { "Id", "Category", "Description" },
                values: new object[] { 3, "SubTask", "Buttons accessed by clicking a main function button. Pertains to the main task" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 1, "Administrator" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 2, "ReportUser" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 3, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 14, true, false, 3, "5551", "Subject 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 13, true, false, 3, "5550", "Subject 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 12, true, false, 3, "2003", "Operator 4" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 11, true, false, 3, "2002", "Operator 3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 10, true, false, 3, "2001", "Operator 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 9, true, false, 3, "2000", "Operator 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 8, true, false, 3, "1004", "User 4" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 5, true, false, 3, "0003", "User 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 6, true, false, 3, "1003", "User 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 15, true, false, 3, "5552", "Subject 3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 4, true, false, 2, "1002", "Report User 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 3, true, false, 2, "0002", "Report User 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 2, true, false, 1, "1001", "Administrator 2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 1, true, false, 1, "0001", "Administrator 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 7, true, false, 3, "0004", "User 3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "IsOnline", "RoleId", "UserId", "Username" },
                values: new object[] { 16, true, false, 3, "5553", "Subject 4" });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 1, 1, "Start Day", 1, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 20, 3, "Clean Up", 32, 30 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 19, 3, "Road Work", 31, 30 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 17, 3, "Equipment Issue", 23, 20 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 16, 3, "Water Road", 22, 20 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 15, 3, "Fill Truck", 21, 20 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 13, 3, "Equipment Issue", 15, 10 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 12, 3, "Fork Work", 14, 10 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 11, 3, "Move Material", 13, 10 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 10, 3, "Load Truck", 12, 10 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 9, 3, "Load Scalper", 11, 10 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 18, 2, "Select Tractor", 30, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 14, 2, "Select Water Truck", 20, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 8, 2, "Select Loader", 10, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 7, 1, "Off Duty", 9, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 6, 1, "End Break", 6, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 5, 1, "Start Break", 5, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 4, 1, "End Lunch", 4, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 3, 1, "Start Lunch", 3, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 2, 1, "End Day", 2, null });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 21, 3, "Fork Work", 33, 30 });

            migrationBuilder.InsertData(
                table: "ButtonCommands",
                columns: new[] { "Id", "CategoryId", "Command", "CommandId", "ParentId" },
                values: new object[] { 22, 3, "Equipment Issue", 34, 30 });

            migrationBuilder.CreateIndex(
                name: "IX_ButtonCommands_CategoryId",
                table: "ButtonCommands",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandLog_CommandId",
                table: "CommandLog",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandLog_UserId1",
                table: "CommandLog",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandLog");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ButtonCommands");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ButtonCommandCategories");
        }
    }
}
