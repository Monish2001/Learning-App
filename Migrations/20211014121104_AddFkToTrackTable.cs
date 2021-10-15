using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_App.Migrations
{
    public partial class AddFkToTrackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackExcercises_Excercises_ExcerciseId",
                table: "TrackExcercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackExcercises_Students_StudentId",
                table: "TrackExcercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackPdf_Contents_ContentId",
                table: "TrackPdf");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackPdf_Students_StudentId",
                table: "TrackPdf");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackVideos_Contents_ContentId",
                table: "TrackVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackVideos_Students_StudentId",
                table: "TrackVideos");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackVideos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContentId",
                table: "TrackVideos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackPdf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContentId",
                table: "TrackPdf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackExcercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExcerciseId",
                table: "TrackExcercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExcercises_Excercises_ExcerciseId",
                table: "TrackExcercises",
                column: "ExcerciseId",
                principalTable: "Excercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExcercises_Students_StudentId",
                table: "TrackExcercises",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackPdf_Contents_ContentId",
                table: "TrackPdf",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackPdf_Students_StudentId",
                table: "TrackPdf",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackVideos_Contents_ContentId",
                table: "TrackVideos",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackVideos_Students_StudentId",
                table: "TrackVideos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackExcercises_Excercises_ExcerciseId",
                table: "TrackExcercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackExcercises_Students_StudentId",
                table: "TrackExcercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackPdf_Contents_ContentId",
                table: "TrackPdf");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackPdf_Students_StudentId",
                table: "TrackPdf");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackVideos_Contents_ContentId",
                table: "TrackVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackVideos_Students_StudentId",
                table: "TrackVideos");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackVideos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContentId",
                table: "TrackVideos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackPdf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContentId",
                table: "TrackPdf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TrackExcercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExcerciseId",
                table: "TrackExcercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExcercises_Excercises_ExcerciseId",
                table: "TrackExcercises",
                column: "ExcerciseId",
                principalTable: "Excercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackExcercises_Students_StudentId",
                table: "TrackExcercises",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackPdf_Contents_ContentId",
                table: "TrackPdf",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackPdf_Students_StudentId",
                table: "TrackPdf",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackVideos_Contents_ContentId",
                table: "TrackVideos",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackVideos_Students_StudentId",
                table: "TrackVideos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
