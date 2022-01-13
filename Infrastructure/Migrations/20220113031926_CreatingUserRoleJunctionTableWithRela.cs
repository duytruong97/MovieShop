using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreatingUserRoleJunctionTableWithRela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUserRole");

            migrationBuilder.DropTable(
                name: "UserUserRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole");

            migrationBuilder.CreateTable(
                name: "RoleUserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UsersOfRoleUserId = table.Column<int>(type: "int", nullable: false),
                    UsersOfRoleRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUserRole", x => new { x.RoleId, x.UsersOfRoleUserId, x.UsersOfRoleRoleId });
                    table.ForeignKey(
                        name: "FK_RoleUserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUserRole_UserRole_UsersOfRoleUserId_UsersOfRoleRoleId",
                        columns: x => new { x.UsersOfRoleUserId, x.UsersOfRoleRoleId },
                        principalTable: "UserRole",
                        principalColumns: new[] { "UserId", "RoleId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolesOfUserUserId = table.Column<int>(type: "int", nullable: false),
                    RolesOfUserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserRole", x => new { x.UserId, x.RolesOfUserUserId, x.RolesOfUserRoleId });
                    table.ForeignKey(
                        name: "FK_UserUserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserRole_UserRole_RolesOfUserUserId_RolesOfUserRoleId",
                        columns: x => new { x.RolesOfUserUserId, x.RolesOfUserRoleId },
                        principalTable: "UserRole",
                        principalColumns: new[] { "UserId", "RoleId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserRole_UsersOfRoleUserId_UsersOfRoleRoleId",
                table: "RoleUserRole",
                columns: new[] { "UsersOfRoleUserId", "UsersOfRoleRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserUserRole_RolesOfUserUserId_RolesOfUserRoleId",
                table: "UserUserRole",
                columns: new[] { "RolesOfUserUserId", "RolesOfUserRoleId" });
        }
    }
}
