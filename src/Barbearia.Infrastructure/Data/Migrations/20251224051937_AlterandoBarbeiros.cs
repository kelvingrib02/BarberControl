using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoBarbeiros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Agendamentos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Servicos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DuracaoMinutos",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Servicos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Barbeiros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Barbeiros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BarbeiroId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Agendamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "Agendamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_BarbeiroId",
                table: "Agendamentos",
                column: "BarbeiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Barbeiros_BarbeiroId",
                table: "Agendamentos",
                column: "BarbeiroId",
                principalTable: "Barbeiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Clientes_ClienteId",
                table: "Agendamentos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Barbeiros_BarbeiroId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Clientes_ClienteId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Servicos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_BarbeiroId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ClienteId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ServicoId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "DuracaoMinutos",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Barbeiros");

            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Barbeiros");

            migrationBuilder.DropColumn(
                name: "BarbeiroId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Agendamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
