using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Type (Description) VALUES ('Pink')");
            migrationBuilder.Sql("INSERT INTO Type (Description) VALUES ('Regular')");
            migrationBuilder.Sql("INSERT INTO Size (Description) VALUES ('Regular')");
            migrationBuilder.Sql("INSERT INTO Size (Description) VALUES ('Large')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
