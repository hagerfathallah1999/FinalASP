using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalASP.Migrations
{
    /// <inheritdoc />
    public partial class mariaaaam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "DeliveryCompanys",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo",
                table: "DeliveryCompanys");
        }
    }
}
