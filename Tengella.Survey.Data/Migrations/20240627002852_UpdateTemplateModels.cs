using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tengella.Survey.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTemplateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyTemplateId",
                table: "TemplateQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionType",
                table: "TemplateQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TemplateQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "QuestionPosition",
                table: "TemplateQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TemplateQuestionId",
                table: "TemplateChoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ChoiceText",
                table: "TemplateChoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ChoicePosition",
                table: "TemplateChoices",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "SurveyTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SurveyTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 1,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 2,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 3,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 4,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 5,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 6,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 7,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 8,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 9,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 10,
                column: "ChoicePosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 1,
                column: "QuestionPosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 2,
                column: "QuestionPosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 3,
                column: "QuestionPosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 4,
                column: "QuestionPosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 5,
                column: "QuestionPosition",
                value: null);

            migrationBuilder.UpdateData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 6,
                column: "QuestionPosition",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices",
                column: "TemplateQuestionId",
                principalTable: "TemplateQuestions",
                principalColumn: "TemplateQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions",
                column: "SurveyTemplateId",
                principalTable: "SurveyTemplates",
                principalColumn: "SurveyTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionPosition",
                table: "TemplateQuestions");

            migrationBuilder.DropColumn(
                name: "ChoicePosition",
                table: "TemplateChoices");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyTemplateId",
                table: "TemplateQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionType",
                table: "TemplateQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TemplateQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TemplateQuestionId",
                table: "TemplateChoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChoiceText",
                table: "TemplateChoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "SurveyTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SurveyTemplates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices",
                column: "TemplateQuestionId",
                principalTable: "TemplateQuestions",
                principalColumn: "TemplateQuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions",
                column: "SurveyTemplateId",
                principalTable: "SurveyTemplates",
                principalColumn: "SurveyTemplateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
