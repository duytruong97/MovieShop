using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreatingUserRoleJunctionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUserRole");

            migrationBuilder.DropTable(
                name: "UserUserRole");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
