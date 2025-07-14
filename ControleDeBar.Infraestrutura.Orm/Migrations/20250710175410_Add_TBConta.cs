using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeBar.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContaId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titular = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MesaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GarcomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Abertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fechamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstaAberta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Garcons_GarcomId",
                        column: x => x.GarcomId,
                        principalTable: "Garcons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ContaId",
                table: "Pedidos",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_GarcomId",
                table: "Contas",
                column: "GarcomId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_MesaId",
                table: "Contas",
                column: "MesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Contas_ContaId",
                table: "Pedidos",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Contas_ContaId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ContaId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Pedidos");
        }
    }
}
