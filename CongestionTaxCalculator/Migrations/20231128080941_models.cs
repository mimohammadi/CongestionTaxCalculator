using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongestionTaxCalculator.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxFees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdateOn = table.Column<DateTime>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Fee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxFreeRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdateOn = table.Column<DateTime>(nullable: true),
                    Category = table.Column<byte>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Day = table.Column<int>(nullable: true),
                    Month = table.Column<int>(nullable: true),
                    Vehicle = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxFreeRules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxFees");

            migrationBuilder.DropTable(
                name: "TaxFreeRules");
        }
    }
}
