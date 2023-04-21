using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalASP.Migrations
{
    /// <inheritdoc />
    public partial class databasecreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryCompanys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CoverageArea = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalKitchens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Locaion = table.Column<string>(type: "text", nullable: false),
                    LogoImage = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<double>(type: "double precision", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalKitchens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VirtualKitchens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    LogoImage = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<double>(type: "double precision", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualKitchens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitchens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Locaion = table.Column<string>(type: "text", nullable: false),
                    KitchenImages = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PhysicalKitchenId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitchens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitchens_PhysicalKitchens_PhysicalKitchenId",
                        column: x => x.PhysicalKitchenId,
                        principalTable: "PhysicalKitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalOrderLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhysicalKitchenID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalOrderLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalOrderLists_PhysicalKitchens_PhysicalKitchenID",
                        column: x => x.PhysicalKitchenID,
                        principalTable: "PhysicalKitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierMatrials",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<double>(type: "double precision", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierMatrials", x => x.id);
                    table.ForeignKey(
                        name: "FK_SupplierMatrials_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VirtualKitchenID = table.Column<int>(type: "integer", nullable: false),
                    PhysicalKitchenID = table.Column<int>(type: "integer", nullable: false),
                    kitchenID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_Kitchens_kitchenID",
                        column: x => x.kitchenID,
                        principalTable: "Kitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_PhysicalKitchens_PhysicalKitchenID",
                        column: x => x.PhysicalKitchenID,
                        principalTable: "PhysicalKitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_VirtualKitchens_VirtualKitchenID",
                        column: x => x.VirtualKitchenID,
                        principalTable: "VirtualKitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order = table.Column<string>(type: "text", nullable: false),
                    OrderSource = table.Column<string>(type: "text", nullable: false),
                    Orderdestination = table.Column<string>(type: "text", nullable: false),
                    OrderPrice = table.Column<double>(type: "double precision", nullable: false),
                    DeliveryOption = table.Column<bool>(type: "boolean", nullable: false),
                    PhysicalOrderListID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalOrders_PhysicalOrderLists_PhysicalOrderListID",
                        column: x => x.PhysicalOrderListID,
                        principalTable: "PhysicalOrderLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirtualOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order = table.Column<string>(type: "text", nullable: false),
                    OrderSource = table.Column<string>(type: "text", nullable: false),
                    Orderdestination = table.Column<string>(type: "text", nullable: false),
                    OrderPrice = table.Column<double>(type: "double precision", nullable: false),
                    DeliveryOption = table.Column<bool>(type: "boolean", nullable: false),
                    ReservationID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualOrders_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitchens_PhysicalKitchenId",
                table: "Kitchens",
                column: "PhysicalKitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalOrderLists_PhysicalKitchenID",
                table: "PhysicalOrderLists",
                column: "PhysicalKitchenID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalOrders_PhysicalOrderListID",
                table: "PhysicalOrders",
                column: "PhysicalOrderListID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_kitchenID",
                table: "Reservations",
                column: "kitchenID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PhysicalKitchenID",
                table: "Reservations",
                column: "PhysicalKitchenID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VirtualKitchenID",
                table: "Reservations",
                column: "VirtualKitchenID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierMatrials_SupplierId",
                table: "SupplierMatrials",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualOrders_ReservationID",
                table: "VirtualOrders",
                column: "ReservationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryCompanys");

            migrationBuilder.DropTable(
                name: "PhysicalOrders");

            migrationBuilder.DropTable(
                name: "SupplierMatrials");

            migrationBuilder.DropTable(
                name: "VirtualOrders");

            migrationBuilder.DropTable(
                name: "PhysicalOrderLists");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Kitchens");

            migrationBuilder.DropTable(
                name: "VirtualKitchens");

            migrationBuilder.DropTable(
                name: "PhysicalKitchens");
        }
    }
}
