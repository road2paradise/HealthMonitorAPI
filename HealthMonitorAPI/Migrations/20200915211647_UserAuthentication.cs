using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthMonitorAPI.Migrations
{
    public partial class UserAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRoles",
                table: "User",
                nullable: false,
                defaultValue: "User",
                defaultValueSql: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserRoles",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Username");
        }
    }
}
