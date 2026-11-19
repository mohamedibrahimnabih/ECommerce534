using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce534.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMockDataToBrandModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Brands (Name, Logo, Status) values ('Apple', 'logo1.png', 1);insert into Brands (Name, Logo, Status) values ('Samsung', 'logo2.png', 1);insert into Brands (Name, Logo, Status) values ('Sony', 'logo3.png', 1);insert into Brands (Name, Logo, Status) values ('Dell', 'logo4.png', 1);insert into Brands (Name, Logo, Status) values ('HP', 'logo5.png', 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Brands");
        }
    }
}
