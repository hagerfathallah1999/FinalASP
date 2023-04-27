using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalASP.Migrations
{
    /// <inheritdoc />
    public partial class imagebyte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "LogoImage",
                table: "PhysicalKitchens",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LogoImage",
                table: "PhysicalKitchens",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
}
