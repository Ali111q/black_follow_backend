using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaragesStructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderNumberToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("995f3d1d-6a23-47ed-8a7c-408f681178e1"));

            migrationBuilder.AddColumn<int>(
                name: "orderNumber",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categoriess",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eecdaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 27, 16, 11, 10, 425, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 27, 16, 11, 10, 293, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 27, 16, 11, 10, 293, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("57c0dc20-d93b-49a4-bad2-e38bdeb68b02"), new DateTime(2024, 8, 27, 16, 11, 10, 425, DateTimeKind.Utc).AddTicks(7680), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 27, 16, 11, 10, 425, DateTimeKind.Utc).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 8, 27, 16, 11, 10, 293, DateTimeKind.Utc).AddTicks(9000), "$2a$10$Ch.g.oVnmHTjt.3eH1sNdOjaIn6E8wF.vemURueimeUBPdUv/kKve" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("57c0dc20-d93b-49a4-bad2-e38bdeb68b02"));

            migrationBuilder.DropColumn(
                name: "orderNumber",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categoriess",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eecdaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 25, 17, 48, 33, 337, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 25, 17, 48, 33, 207, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 25, 17, 48, 33, 207, DateTimeKind.Utc).AddTicks(3780));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("995f3d1d-6a23-47ed-8a7c-408f681178e1"), new DateTime(2024, 8, 25, 17, 48, 33, 337, DateTimeKind.Utc).AddTicks(2230), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 25, 17, 48, 33, 337, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 8, 25, 17, 48, 33, 207, DateTimeKind.Utc).AddTicks(3830), "$2a$10$iYuH7lkIXoM.x.ngimOYA.alu8sSKMwLT/RW94TPA1l6Ie10uEn52" });
        }
    }
}
