using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoAgendamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Agendamentos",
                newName: "DataHoraInicio");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Agendamentos",
                newName: "DataHoraFim");

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "Agendamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "DataHoraInicio",
                table: "Agendamentos",
                newName: "DataHora");

            migrationBuilder.RenameColumn(
                name: "DataHoraFim",
                table: "Agendamentos",
                newName: "DataCriacao");

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
