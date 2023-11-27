using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTravelCompany.Migrations
{
    /// <inheritdoc />
    public partial class HouseAmenities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAitConditioner",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPool",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTv",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasWifi",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAitConditioner",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "HasPool",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "HasTv",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "HasWifi",
                table: "Houses");
        }
    }
}
