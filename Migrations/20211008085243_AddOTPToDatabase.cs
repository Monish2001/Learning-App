using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_App.Migrations
{
    public partial class AddOTPToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollments_Students_StudentId",
                table: "StudentEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollments_StudentId",
                table: "StudentEnrollments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentEnrollments");

            migrationBuilder.AddColumn<int>(
                name: "OtpId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentEnrollmentId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OTP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneratedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Otp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTP", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_OtpId",
                table: "Students",
                column: "OtpId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentEnrollmentId",
                table: "Students",
                column: "StudentEnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_OTP_OtpId",
                table: "Students",
                column: "OtpId",
                principalTable: "OTP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentEnrollments_StudentEnrollmentId",
                table: "Students",
                column: "StudentEnrollmentId",
                principalTable: "StudentEnrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_OTP_OtpId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentEnrollments_StudentEnrollmentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "OTP");

            migrationBuilder.DropIndex(
                name: "IX_Students_OtpId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentEnrollmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "OtpId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentEnrollmentId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentEnrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_StudentId",
                table: "StudentEnrollments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollments_Students_StudentId",
                table: "StudentEnrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
