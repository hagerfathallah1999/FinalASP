using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalASP.Migrations
{
    /// <inheritdoc />
    public partial class mariooom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "SupplierMatrials");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "SupplierMatrials",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "SupplierMatrials",
                newName: "image");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "SupplierMatrials",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
