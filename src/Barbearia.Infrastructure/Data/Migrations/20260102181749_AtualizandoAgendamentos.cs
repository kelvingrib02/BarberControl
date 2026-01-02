using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoAgendamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraFim",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "DataHoraInicio",
                table: "Agendamentos",
                newName: "DataHora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Agendamentos",
                newName: "DataHoraInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraFim",
                table: "Agendamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
