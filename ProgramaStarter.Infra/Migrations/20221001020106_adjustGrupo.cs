using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramaStarter.Infra.Data.Migrations
{
    public partial class adjustGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Starters_Grupos_GrupoId",
                table: "Starters");

            migrationBuilder.AlterColumn<int>(
                name: "GrupoId",
                table: "Starters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Starters_Grupos_GrupoId",
                table: "Starters",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Starters_Grupos_GrupoId",
                table: "Starters");

            migrationBuilder.AlterColumn<int>(
                name: "GrupoId",
                table: "Starters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Starters_Grupos_GrupoId",
                table: "Starters",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
