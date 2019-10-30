using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Services.Migrations
{
    public partial class AlteraLancamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCredit",
                table: "Lancamento",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "ContaCorrente",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCredit",
                table: "Lancamento");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "ContaCorrente",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
