using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_App.Migrations
{
    public partial class NewColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Createdtime",
                table: "Votes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Completeduration",
                table: "TrackVideos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Totalduration",
                table: "TrackVideos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Endtime",
                table: "TrackExcercises",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Starttime",
                table: "TrackExcercises",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Dob",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Createdtime",
                table: "Sessions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Timelimit",
                table: "Questions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Generatedtime",
                table: "OTP",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Createdtime",
                table: "Notes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Timelimit",
                table: "Excercises",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Createdtime",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "Completeduration",
                table: "TrackVideos");

            migrationBuilder.DropColumn(
                name: "Totalduration",
                table: "TrackVideos");

            migrationBuilder.DropColumn(
                name: "Endtime",
                table: "TrackExcercises");

            migrationBuilder.DropColumn(
                name: "Starttime",
                table: "TrackExcercises");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Createdtime",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Timelimit",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Generatedtime",
                table: "OTP");

            migrationBuilder.DropColumn(
                name: "Createdtime",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Timelimit",
                table: "Excercises");
        }
    }
}
