using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_App.Migrations
{
    public partial class AlterTrackQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackQuestions_Questions_QuestionId",
                table: "TrackQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackQuestions_Students_StudentId",
                table: "TrackQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackQuestions_TrackExcercises_TrackExcerciseId",
                table: "TrackQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TrackQuestions_QuestionId",
                table: "TrackQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TrackQuestions_TrackExcerciseId",
                table: "TrackQuestions");

            migrationBuilder.DropColumn(
                name: "Attempted",
                table: "TrackQuestions");

            migrationBuilder.DropColumn(
                name: "MarksObtained",
                table: "TrackQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "TrackExcerciseId",
                table: "TrackQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "TrackQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackQuestions_Students_StudentId",
                table: "TrackQuestions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackQuestions_Students_StudentId",
                table: "TrackQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "TrackExcerciseId",
                table: "TrackQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "TrackQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Attempted",
                table: "TrackQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MarksObtained",
                table: "TrackQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrackQuestions_QuestionId",
                table: "TrackQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackQuestions_TrackExcerciseId",
                table: "TrackQuestions",
                column: "TrackExcerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackQuestions_Questions_QuestionId",
                table: "TrackQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackQuestions_Students_StudentId",
                table: "TrackQuestions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackQuestions_TrackExcercises_TrackExcerciseId",
                table: "TrackQuestions",
                column: "TrackExcerciseId",
                principalTable: "TrackExcercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
