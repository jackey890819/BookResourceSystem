using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookResourceSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeTrackedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "PublishingHouses");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "BookLanguages");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "PublishingHouses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Books",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "BookLanguages",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Authors",
                newName: "CreatedAt");

            migrationBuilder.AlterTable(
                name: "PublishingHouses",
                comment: "出版社實體");

            migrationBuilder.AlterTable(
                name: "Books",
                comment: "圖書實體");

            migrationBuilder.AlterTable(
                name: "Authors",
                comment: "作者實體");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PublishingHouses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BookLanguages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAt", "Introduction", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2f8ecdce-de59-4bd1-bf85-2339efaf2d3e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "測試作者A", null },
                    { new Guid("502a096f-402e-4e5d-b797-661c80cef1fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "測試作者B", null },
                    { new Guid("fcecfd23-beb0-4079-acd5-37b2c1fd97a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "測試作者C", null }
                });

            migrationBuilder.InsertData(
                table: "PublishingHouses",
                columns: new[] { "Id", "CreatedAt", "Introduction", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0b683c48-7f19-4025-9fb6-996e36629e25"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "測試出版社B", null },
                    { new Guid("7b810218-da4f-49c9-a2a8-11d34fd58f4f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "測試出版社A資訊", "測試出版社A", null }
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_BookLanguages_Name_MinLength",
                table: "BookLanguages",
                sql: "LEN([Name]) >= 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_BookLanguages_Name_MinLength",
                table: "BookLanguages");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("2f8ecdce-de59-4bd1-bf85-2339efaf2d3e"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("502a096f-402e-4e5d-b797-661c80cef1fc"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("fcecfd23-beb0-4079-acd5-37b2c1fd97a9"));

            migrationBuilder.DeleteData(
                table: "PublishingHouses",
                keyColumn: "Id",
                keyValue: new Guid("0b683c48-7f19-4025-9fb6-996e36629e25"));

            migrationBuilder.DeleteData(
                table: "PublishingHouses",
                keyColumn: "Id",
                keyValue: new Guid("7b810218-da4f-49c9-a2a8-11d34fd58f4f"));

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PublishingHouses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BookLanguages");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PublishingHouses",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Books",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BookLanguages",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Authors",
                newName: "LastUpdated");

            migrationBuilder.AlterTable(
                name: "PublishingHouses",
                oldComment: "出版社實體");

            migrationBuilder.AlterTable(
                name: "Books",
                oldComment: "圖書實體");

            migrationBuilder.AlterTable(
                name: "Authors",
                oldComment: "作者實體");

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "PublishingHouses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "BookLanguages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
