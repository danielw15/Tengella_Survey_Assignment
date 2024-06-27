using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tengella.Survey.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedChoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Choices",
                newName: "ChoiceText");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Choices",
                newName: "ChoicePosition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChoiceText",
                table: "Choices",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "ChoicePosition",
                table: "Choices",
                newName: "Position");
        }
    }
}
