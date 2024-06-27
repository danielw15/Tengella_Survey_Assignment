using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tengella.Survey.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyObjectId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions",
                column: "SurveyObjectId",
                principalTable: "SurveyObjects",
                principalColumn: "SurveyObjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyObjectId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions",
                column: "SurveyObjectId",
                principalTable: "SurveyObjects",
                principalColumn: "SurveyObjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
