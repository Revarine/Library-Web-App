using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesAndConfigurationsFLUENT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TakenBooks_UserId",
                table: "TakenBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TakenBooks",
                table: "TakenBooks",
                columns: new[] { "UserId", "BookId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TakenBooks",
                table: "TakenBooks");

            migrationBuilder.CreateIndex(
                name: "IX_TakenBooks_UserId",
                table: "TakenBooks",
                column: "UserId");
        }
    }
}
