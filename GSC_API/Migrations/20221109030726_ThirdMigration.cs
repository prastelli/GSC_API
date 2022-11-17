using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSC_API.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rol_RolId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "RoleModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleModel",
                table: "RoleModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleModel_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "RoleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleModel_RolId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleModel",
                table: "RoleModel");

            migrationBuilder.RenameTable(
                name: "RoleModel",
                newName: "Rol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rol_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
