using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagementPortal.Entities.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Position = table.Column<string>(maxLength: 20, nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "ZipCode" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Gdynia", "Poland", "Filipkowskiego 20A/22", "81578" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "ZipCode" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Chwaszczyno", "Poland", "Buraczana", "80209" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "ZipCode" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Gdańsk", "Poland", "Kolarska 8E", "80-180" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Age", "Email", "Gender", "LastName", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("dc003aa0-8f29-4be3-a623-69fc9136e9d2"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 5, "sisi.kaczuszka@wp.pl", 1, "Murlik", "Sisi", "666666666" },
                    { new Guid("daa46f02-4e4e-4342-bd74-0714b77ed535"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 3, "amor.buziaczek@onet.pl", 0, "Murlik", "Amor", "555-555-555" },
                    { new Guid("e0219757-b2e6-46b3-855b-335f2d9a94cc"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 17, "prywatny.murlik@gmail.com", 1, "Murlik", "Paula", "537843591" },
                    { new Guid("46b94aac-2f6e-4b0f-b0ae-f18549b96b36"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 28, "aleksandra.czerwa@gmail.com", 1, "Czerwińska", "Aleksandra", "506139325" },
                    { new Guid("5b686772-258f-412c-9c00-4d29fdef1fb7"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 21, "kacper.berganski@onet.com", 0, "Bergański", "Kacper", "720860430" },
                    { new Guid("c6e963ae-ca9e-4bcb-9c13-a58c2f7b0ffa"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 0, "", 1, "Bergańska", "Daria", "" },
                    { new Guid("a5fe7e0b-dfe3-466a-8e4b-865a0c7ed374"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 20, "j.czerwinska@o2.pl", 1, "Czerwińska", "Julia", "512899657" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AddressId",
                table: "Employee",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
