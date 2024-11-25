using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePontoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSenhaAndRoleForFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Funcionarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosPonto_FuncionarioId",
                table: "RegistrosPonto",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPonto_Funcionarios_FuncionarioId",
                table: "RegistrosPonto",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPonto_Funcionarios_FuncionarioId",
                table: "RegistrosPonto");

            migrationBuilder.DropIndex(
                name: "IX_RegistrosPonto_FuncionarioId",
                table: "RegistrosPonto");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
