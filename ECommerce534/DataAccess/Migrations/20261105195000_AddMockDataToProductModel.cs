using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce534.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMockDataToProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('MacBook Pro 14', 'Apple M3 Pro chip, 18GB RAM, 512GB SSD', 'img1.png', 1999.99, 150.00, 30, 1, 1, 1);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('MacBook Air M2', 'Apple M2 chip, 8GB RAM, 256GB SSD', 'img2.png', 1299.99, 0.00, 50, 1, 1, 1);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Samsung Galaxy Book3', 'Intel Core i7, 16GB RAM, 512GB SSD', 'img3.png', 1099.99, 100.00, 25, 1, 1, 2);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Dell XPS 15', 'Intel Core i9, 32GB RAM, 1TB SSD, OLED Display', 'img4.png', 1799.99, 200.00, 15, 1, 1, 4);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('HP Spectre x360', 'Intel Core i7, 16GB RAM, 512GB SSD, 2-in-1', 'img5.png', 1499.99, 0.00, 20, 1, 1, 5);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Dell Inspiron 15', 'Intel Core i5, 8GB RAM, 256GB SSD', 'img6.png', 799.99, 50.00, 40, 1, 1, 4);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Sony Alpha A7 IV', 'Full-frame mirrorless camera, 33MP sensor', 'img7.png', 2499.99, 0.00, 10, 1, 2, 3);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Sony ZV-E10', 'APS-C mirrorless camera, 24.2MP, ideal for vlogging', 'img8.png', 749.99, 75.00, 20, 1, 2, 3);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('iPhone 15 Pro', 'A17 Pro chip, 48MP camera, titanium design', 'img9.png', 1199.99, 0.00, 60, 1, 3, 1);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('iPhone 14', 'A15 Bionic chip, 12MP dual camera', 'img10.png', 799.99, 100.00, 45, 1, 3, 1);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Samsung Galaxy S24', 'Snapdragon 8 Gen 3, 50MP camera, 6.2'' display', 'img11.png', 999.99, 0.00, 55, 1, 3, 2);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Samsung Galaxy A54', 'Exynos 1380, 50MP camera, 6.4'' display', 'img12.png', 449.99, 50.00, 70, 1, 3, 2);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Sony Bravia 55'' 4K', '55-inch 4K OLED, Dolby Vision, Google TV', 'img13.png', 1299.99, 150.00, 18, 1, 4, 3);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Samsung QLED 65''', '65-inch QLED 4K, 120Hz, Smart TV', 'img14.png', 1799.99, 200.00, 12, 1, 4, 2);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Apple AirPods Pro', 'Active noise cancellation, Adaptive Transparency', 'img15.png', 249.99, 0.00, 100, 1, 5, 1);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Samsung Galaxy Buds2', 'Active noise cancellation, 3-mic system', 'img16.png', 149.99, 30.00, 80, 1, 5, 2);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Sony WH-1000XM5', 'Industry-leading noise cancellation headphones', 'img17.png', 349.99, 0.00, 60, 1, 5, 3);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('Dell UltraSharp 27''', '27-inch 4K USB-C monitor, 99% sRGB', 'img18.png', 599.99, 0.00, 25, 1, 5, 4);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('HP LaserJet Pro', 'Monochrome laser printer, wireless, duplex', 'img19.png', 299.99, 25.00, 35, 1, 5, 5);" +
                "insert into Products (Name, Description, MainImg, Price, Discount, Quantity, Status, CategoryId, BrandId) values ('HP Pavilion 15', 'AMD Ryzen 5, 8GB RAM, 512GB SSD, 15.6'' FHD', 'img20.png', 899.99, 0.00, 30, 1, 1, 5);"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
