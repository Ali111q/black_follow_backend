using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaragesStructure.Migrations
{
    /// <inheritdoc />
    public partial class newmigrates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("fd050388-859c-484b-a474-da42273b152b"));

            migrationBuilder.DropColumn(
                name: "AcceptedUserId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categoriess",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eecdaa"),
                column: "CreationDate",
                value: new DateTime(2024, 10, 7, 0, 34, 43, 402, DateTimeKind.Utc).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 10, 7, 0, 34, 43, 309, DateTimeKind.Utc).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 10, 7, 0, 34, 43, 309, DateTimeKind.Utc).AddTicks(1230));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("3bfdbe88-26d3-4c91-bbe1-9faa56b09536"), new DateTime(2024, 10, 7, 0, 34, 43, 402, DateTimeKind.Utc).AddTicks(7780), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 10, 7, 0, 34, 43, 402, DateTimeKind.Utc).AddTicks(7740));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 10, 7, 0, 34, 43, 309, DateTimeKind.Utc).AddTicks(1270), "$2a$10$cbp1mM40EOInsDmUcN7FIepqTfyE1GmubQ3OeyC22PX0DGAzcs1gC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3bfdbe88-26d3-4c91-bbe1-9faa56b09536"));

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
                value: new DateTime(2024, 9, 1, 18, 11, 32, 268, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                column: "CreationDate",
                value: new DateTime(2024, 9, 1, 18, 11, 32, 134, DateTimeKind.Utc).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                column: "CreationDate",
                value: new DateTime(2024, 9, 1, 18, 11, 32, 134, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Deleted", "Description", "Icon", "Maximum", "Minimum", "Name", "ServiceId", "ServicePrice", "SubCategoryId" },
                values: new object[] { new Guid("fd050388-859c-484b-a474-da42273b152b"), new DateTime(2024, 9, 1, 18, 11, 32, 268, DateTimeKind.Utc).AddTicks(5590), false, "add followers", "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png", "100000", "50", "add  followers", "982", null, new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa") });

            migrationBuilder.UpdateData(
                table: "SubCategorys",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeadaa"),
                column: "CreationDate",
                value: new DateTime(2024, 9, 1, 18, 11, 32, 268, DateTimeKind.Utc).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 1, 18, 11, 32, 134, DateTimeKind.Utc).AddTicks(3080), "$2a$10$0uH.g5mXaIHiwnKrnOLbH.bSojYoE2L3SHY7xLfXxvPit.VAqZi7m" });

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
    }
}
