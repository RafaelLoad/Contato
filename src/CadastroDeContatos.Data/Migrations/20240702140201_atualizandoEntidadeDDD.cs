using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDeContatos.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizandoEntidadeDDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Ddd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Ddd",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
