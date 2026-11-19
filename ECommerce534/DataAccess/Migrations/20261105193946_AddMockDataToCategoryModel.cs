using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce534.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMockDataToCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categories (Name, Status) values ('Laptops', 1);insert into Categories (Name, Status) values ('Cameras', 1);insert into Categories (Name, Status) values ('Mobiles', 1);insert into Categories (Name, Status) values ('TVs', 0);insert into Categories (Name, Status) values ('Accessories', 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Categories");
        }
    }
}
