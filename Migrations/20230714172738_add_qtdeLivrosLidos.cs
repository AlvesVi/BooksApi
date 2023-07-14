using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksApi.Migrations
{
    /// <inheritdoc />
    public partial class add_qtdeLivrosLidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditoraId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "QuantidadePaginas",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "GerenoId",
                table: "Livros",
                newName: "GeneroId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "ListasdeLeitura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QtdeLivrosLidos",
                table: "ListasdeLeitura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataPublicacao",
                value: new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2139));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdeLivrosLidos",
                table: "ListasdeLeitura");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "Livros",
                newName: "GerenoId");

            migrationBuilder.AddColumn<int>(
                name: "EditoraId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadePaginas",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Descricao",
                table: "ListasdeLeitura",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Livros",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DataPublicacao", "EditoraId", "QuantidadePaginas" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
