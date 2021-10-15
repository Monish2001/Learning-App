using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_App.Migrations
{
    public partial class AddNullableBoolToVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Createdtime",
                table: "Votes",
                newName: "Votedtime");

            migrationBuilder.AlterColumn<bool>(
                name: "IsVoted",
                table: "Votes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Votedtime",
                table: "Votes",
                newName: "Createdtime");

            migrationBuilder.AlterColumn<bool>(
                name: "IsVoted",
                table: "Votes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
