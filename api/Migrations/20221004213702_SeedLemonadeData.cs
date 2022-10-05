using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class SeedLemonadeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lemonades (typeId, sizeId) VALUES (3, 1)");
            migrationBuilder.Sql("INSERT INTO Lemonades (typeId, sizeId) VALUES (3, 2)");
            migrationBuilder.Sql("INSERT INTO Lemonades (typeId, sizeId) VALUES (4, 1)");
            migrationBuilder.Sql("INSERT INTO Lemonades (typeId, sizeId) VALUES (4, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
