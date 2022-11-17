using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSC_API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rol_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rol_RolId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Users");
        }
    }
}
