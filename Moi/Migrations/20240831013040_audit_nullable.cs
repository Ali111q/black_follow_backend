using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaragesStructure.Migrations
{
    /// <inheritdoc />
    public partial class auditnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("83de5447-acd4-4739-8a69-fd828f69e228"));

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "Audits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "OldValues",
                table: "Audits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NewValues",
                table: "Audits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ChangedBy",
                table: "Audits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Audits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("61b855cd-50e0-48f8-a483-72abbc5a4c6f"));

            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "Audits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OldValues",
                table: "Audits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NewValues",
                table: "Audits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChangedBy",
                table: "Audits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Audits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
    }
}
