using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagementPortal.Entities.Migrations
{
    public partial class CountryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Addresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("46b94aac-2f6e-4b0f-b0ae-f18549b96b36"),
                column: "AddressId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4c980cfa-ded9-4d64-82bd-3d461719249b"),
                column: "AddressId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5b686772-258f-412c-9c00-4d29fdef1fb7"),
                column: "AddressId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c6e963ae-ca9e-4bcb-9c13-a58c2f7b0ffa"),
                column: "AddressId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("daa46f02-4e4e-4342-bd74-0714b77ed535"),
                column: "AddressId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("dc003aa0-8f29-4be3-a623-69fc9136e9d2"),
                column: "AddressId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e0219757-b2e6-46b3-855b-335f2d9a94cc"),
                column: "AddressId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Addresses");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("46b94aac-2f6e-4b0f-b0ae-f18549b96b36"),
                column: "AddressId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4c980cfa-ded9-4d64-82bd-3d461719249b"),
                column: "AddressId",
                value: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5b686772-258f-412c-9c00-4d29fdef1fb7"),
                column: "AddressId",
                value: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c6e963ae-ca9e-4bcb-9c13-a58c2f7b0ffa"),
                column: "AddressId",
                value: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("daa46f02-4e4e-4342-bd74-0714b77ed535"),
                column: "AddressId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("dc003aa0-8f29-4be3-a623-69fc9136e9d2"),
                column: "AddressId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e0219757-b2e6-46b3-855b-335f2d9a94cc"),
                column: "AddressId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
