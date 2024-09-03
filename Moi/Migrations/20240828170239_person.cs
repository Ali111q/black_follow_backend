using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GaragesStructure.Migrations
{
    /// <inheritdoc />
    public partial class person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("57c0dc20-d93b-49a4-bad2-e38bdeb68b02"));

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Speciality = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Disease = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("483840ed-0204-4677-9531-df240f628d88"));

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
    }
}
