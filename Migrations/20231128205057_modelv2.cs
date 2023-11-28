using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTravelCompany.Migrations
{
    /// <inheritdoc />
    public partial class modelv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Houses_HouseId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HouseId",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "HouseId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HouseId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HouseId",
                table: "Bookings",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Houses_HouseId",
                table: "Bookings",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
