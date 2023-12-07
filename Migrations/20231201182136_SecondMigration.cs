using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthPoleGiftSystem.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    WorkshopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopCapacity = table.Column<int>(type: "int", nullable: false),
                    SupervisorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.WorkshopID);
                });

            migrationBuilder.CreateTable(
                name: "Elves",
                columns: table => new
                {
                    ElfID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElfName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElfRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elves", x => x.ElfID);
                    table.ForeignKey(
                        name: "FK_Elves_Workshops_WorkshopID",
                        column: x => x.WorkshopID,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    GiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopID = table.Column<int>(type: "int", nullable: false),
                    ProductionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WishlistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.GiftID);
                    table.ForeignKey(
                        name: "FK_Gifts_Workshops_WorkshopID",
                        column: x => x.WorkshopID,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    WishlistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WishlistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElfID = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.WishlistID);
                    table.ForeignKey(
                        name: "FK_Wishlists_Elves_ElfID",
                        column: x => x.ElfID,
                        principalTable: "Elves",
                        principalColumn: "ElfID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elves_WorkshopID",
                table: "Elves",
                column: "WorkshopID");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_WorkshopID",
                table: "Gifts",
                column: "WorkshopID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ElfID",
                table: "Wishlists",
                column: "ElfID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Elves");

            migrationBuilder.DropTable(
                name: "Workshops");
        }
    }
}
