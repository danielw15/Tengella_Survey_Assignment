using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tengella.Survey.Data.Migrations
{
    /// <inheritdoc />
    public partial class TemplateSurveys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "surveyTemplates",
                columns: table => new
                {
                    SurveyTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveyTemplates", x => x.SurveyTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateQuestions",
                columns: table => new
                {
                    TemplateQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyTemplateId = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateQuestions", x => x.TemplateQuestionId);
                    table.ForeignKey(
                        name: "FK_TemplateQuestions_surveyTemplates_SurveyTemplateId",
                        column: x => x.SurveyTemplateId,
                        principalTable: "surveyTemplates",
                        principalColumn: "SurveyTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateChoices",
                columns: table => new
                {
                    TemplateChoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateQuestionId = table.Column<int>(type: "int", nullable: false),
                    ChoiceText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateChoices", x => x.TemplateChoiceId);
                    table.ForeignKey(
                        name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                        column: x => x.TemplateQuestionId,
                        principalTable: "TemplateQuestions",
                        principalColumn: "TemplateQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateChoices_TemplateQuestionId",
                table: "TemplateChoices",
                column: "TemplateQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateQuestions_SurveyTemplateId",
                table: "TemplateQuestions",
                column: "SurveyTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateChoices");

            migrationBuilder.DropTable(
                name: "TemplateQuestions");

            migrationBuilder.DropTable(
                name: "surveyTemplates");
        }
    }
}
