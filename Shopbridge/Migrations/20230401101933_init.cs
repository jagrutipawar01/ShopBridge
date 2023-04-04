using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopbridge.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    ItemDescription = table.Column<string>(maxLength: 50, nullable: true),
                    ItemCategory = table.Column<string>(nullable: true),
                    ItemQuantity = table.Column<int>(nullable: false),
                    ItemPrice = table.Column<double>(nullable: false),
                    ItemDiscount = table.Column<double>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
