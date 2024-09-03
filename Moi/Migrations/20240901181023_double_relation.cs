using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaragesStructure.Migrations
{
    /// <inheritdoc />
    public partial class doublerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("61b855cd-50e0-48f8-a483-72abbc5a4c6f"));

            migrationBuilder.AddColumn<Guid>(
                name: "AcceptedUserId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Categoriess",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eecdaa"),
                column: "CreationDate",
                value: new DateTime(2024, 9, 1, 18, 10, 23, 626, DateTimeKind.Utc).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 9, 1, 18, 10, 23, 495, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 9, 1, 18, 10, 23, 495, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("0c1d12a3-afde-4dd2-acfe-94d177d62e8a"), new DateTime(2024, 9, 1, 18, 10, 23, 626, DateTimeKind.Utc).AddTicks(4220), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 9, 1, 18, 10, 23, 626, DateTimeKind.Utc).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 1, 18, 10, 23, 495, DateTimeKind.Utc).AddTicks(1230), "$2a$10$DzjGZrmkEzxPvuqDMNXNQeONeYV0ZixIdITH7HntILB8E5sLL0gde" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AcceptedUserId",
                table: "Orders",
                column: "AcceptedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AcceptedUserId",
                table: "Orders",
                column: "AcceptedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_AcceptedUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AcceptedUserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("0c1d12a3-afde-4dd2-acfe-94d177d62e8a"));

            migrationBuilder.DropColumn(
                name: "AcceptedUserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categoriess",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eecdaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 30, 40, 181, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 30, 40, 49, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 30, 40, 49, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("61b855cd-50e0-48f8-a483-72abbc5a4c6f"), new DateTime(2024, 8, 31, 1, 30, 40, 181, DateTimeKind.Utc).AddTicks(5730), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 8, 31, 1, 30, 40, 181, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 8, 31, 1, 30, 40, 49, DateTimeKind.Utc).AddTicks(3200), "$2a$10$f9IrTDrT5.KJ7MRDtN4BsOKOvwzwg7g7NeD6aIDI6fdwv.XIbLuJS" });
        }
    }
}
