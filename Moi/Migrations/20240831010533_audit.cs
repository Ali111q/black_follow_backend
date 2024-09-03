using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaragesStructure.Migrations
{
    /// <inheritdoc />
    public partial class audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("483840ed-0204-4677-9531-df240f628d88"));

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    OldValues = table.Column<string>(type: "text", nullable: false),
                    NewValues = table.Column<string>(type: "text", nullable: false),
                    ChangedBy = table.Column<string>(type: "text", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categoriess",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eecdaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 5, 32, 826, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 5, 32, 696, DateTimeKind.Utc).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 5, 32, 696, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("83de5447-acd4-4739-8a69-fd828f69e228"), new DateTime(2024, 8, 31, 1, 5, 32, 826, DateTimeKind.Utc).AddTicks(2740), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 5, 32, 826, DateTimeKind.Utc).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 8, 31, 1, 5, 32, 696, DateTimeKind.Utc).AddTicks(1170), "$2a$10$fkb1aIaM/yaQASnzf2SvR.hbTQWN1RkMgh6XrcgV2FYUcoWpM7Nnm" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("83de5447-acd4-4739-8a69-fd828f69e228"));

            migrationBuilder.UpdateData(
                table: "Categoriess",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eecdaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 28, 17, 2, 38, 977, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 28, 17, 2, 38, 853, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 28, 17, 2, 38, 853, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("483840ed-0204-4677-9531-df240f628d88"), new DateTime(2024, 8, 28, 17, 2, 38, 977, DateTimeKind.Utc).AddTicks(7880), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 28, 17, 2, 38, 977, DateTimeKind.Utc).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 8, 28, 17, 2, 38, 853, DateTimeKind.Utc).AddTicks(9710), "$2a$10$PVCH68qpjNxBVPdCmhajCuJ0da0wKrkhhTTTgYAD2XgFIKp1EsMXe" });
        }
    }
}
