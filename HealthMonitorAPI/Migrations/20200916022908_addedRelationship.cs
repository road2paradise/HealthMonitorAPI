using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthMonitorAPI.Migrations
{
    public partial class addedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_User_UserID",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_User_UserID",
                table: "Appointment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_User_UserID",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Appointment",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_User_UserID",
                table: "Appointment",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
