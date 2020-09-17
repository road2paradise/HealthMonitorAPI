using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthMonitorAPI.Migrations
{
    public partial class addedRelationship3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_ApplicationUserId",
                table: "Appointment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
