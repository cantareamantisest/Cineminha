using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cineminha.Infraestrutura.Dados.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    IdFilme = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagem = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.IdFilme);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Assentos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Funcao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    IdSessao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFilme = table.Column<int>(type: "int", nullable: false),
                    IdSala = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    ValorIngresso = table.Column<float>(type: "real", nullable: false),
                    TipoAnimacao = table.Column<int>(type: "int", nullable: false),
                    TipoAudio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.IdSessao);
                    table.ForeignKey(
                        name: "FK_Sessao_Filme_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "Filme",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Sala_IdSala",
                        column: x => x.IdSala,
                        principalTable: "Sala",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdFilme",
                table: "Sessao",
                column: "IdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdSala",
                table: "Sessao",
                column: "IdSala");

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 1", 110 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 2", 120 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 3", 130 }); ;

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 4", 140 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 5", 150 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 6", 160 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 7", 170 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 8", 180 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 9", 190 });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Nome", "Assentos" },
                values: new object[] { "Sala 10", 200 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Nome", "Login", "Senha", "Funcao" },
                values: new object[] { "Gerente da PrintWayy", "gerente", "IMfX3dFEQFv5xFRZhIowgQ==", "Gerente" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
