using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_App.Migrations
{
    public partial class RemovedClassesFromStudentEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollments_Classes_ClassId",
                table: "StudentEnrollments");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "StudentEnrollments",
                newName: "ClassesId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollments_ClassId",
                table: "StudentEnrollments",
                newName: "IX_StudentEnrollments_ClassesId");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentEnrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollments_Classes_ClassesId",
                table: "StudentEnrollments",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollments_Classes_ClassesId",
                table: "StudentEnrollments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentEnrollments");

            migrationBuilder.RenameColumn(
                name: "ClassesId",
                table: "StudentEnrollments",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentEnrollments_ClassesId",
                table: "StudentEnrollments",
                newName: "IX_StudentEnrollments_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollments_Classes_ClassId",
                table: "StudentEnrollments",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
