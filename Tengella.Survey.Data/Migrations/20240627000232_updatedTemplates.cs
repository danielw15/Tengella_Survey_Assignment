using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tengella.Survey.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateQuestions_surveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_surveyTemplates",
                table: "surveyTemplates");

            migrationBuilder.RenameTable(
                name: "surveyTemplates",
                newName: "SurveyTemplates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SurveyTemplates",
                table: "SurveyTemplates",
                column: "SurveyTemplateId");

            migrationBuilder.InsertData(
                table: "SurveyTemplates",
                columns: new[] { "SurveyTemplateId", "Description", "TemplateName" },
                values: new object[,]
                {
                    { 1, "Gauge customer satisfaction with our cleaning services.", "Customer Satisfaction Survey" },
                    { 2, "Gather feedback from employees on the cleanliness of the workplace.", "Employee Feedback Survey" },
                    { 3, "Understand market needs and preferences for cleaning services.", "Market Research Survey" }
                });

            migrationBuilder.InsertData(
                table: "TemplateQuestions",
                columns: new[] { "TemplateQuestionId", "QuestionText", "QuestionType", "SurveyTemplateId" },
                values: new object[,]
                {
                    { 1, "How satisfied are you with our cleaning services?", "single_choice", 1 },
                    { 2, "How likely are you to recommend our services to others?", "single_choice", 1 },
                    { 3, "How would you rate the cleanliness of your workspace?", "single_choice", 2 },
                    { 4, "Do you have any suggestions for improving our cleaning services?", "free_text", 2 },
                    { 5, "How often do you use professional cleaning services?", "single_choice", 3 },
                    { 6, "What factors influence your decision to hire a cleaning service?", "multiple_choice", 3 }
                });

            migrationBuilder.InsertData(
                table: "TemplateChoices",
                columns: new[] { "TemplateChoiceId", "ChoiceText", "TemplateQuestionId" },
                values: new object[,]
                {
                    { 1, "Very Satisfied", 1 },
                    { 2, "Satisfied", 1 },
                    { 3, "Neutral", 1 },
                    { 4, "Dissatisfied", 1 },
                    { 5, "Very Dissatisfied", 1 },
                    { 6, "Very Likely", 2 },
                    { 7, "Likely", 2 },
                    { 8, "Neutral", 2 },
                    { 9, "Unlikely", 2 },
                    { 10, "Very Unlikely", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions",
                column: "SurveyTemplateId",
                principalTable: "SurveyTemplates",
                principalColumn: "SurveyTemplateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SurveyTemplates",
                table: "SurveyTemplates");

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SurveyTemplates",
                keyColumn: "SurveyTemplateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SurveyTemplates",
                keyColumn: "SurveyTemplateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SurveyTemplates",
                keyColumn: "SurveyTemplateId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "SurveyTemplates",
                newName: "surveyTemplates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_surveyTemplates",
                table: "surveyTemplates",
                column: "SurveyTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateQuestions_surveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions",
                column: "SurveyTemplateId",
                principalTable: "surveyTemplates",
                principalColumn: "SurveyTemplateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
