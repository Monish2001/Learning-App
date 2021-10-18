using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_App.Migrations
{
    public partial class AddedPagesInTrackPdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "TrackPdf");

            migrationBuilder.AddColumn<int>(
                name: "TotalPages",
                table: "TrackPdf",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewedPages",
                table: "TrackPdf",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPages",
                table: "TrackPdf");

            migrationBuilder.DropColumn(
                name: "ViewedPages",
                table: "TrackPdf");

            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "TrackPdf",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
