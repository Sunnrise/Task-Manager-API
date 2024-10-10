using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_AspNetUsers_UserId",
                table: "Duties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ae76496-54ed-45c2-99a2-26affc020193"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Duties",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Duties_UserId",
                table: "Duties",
                newName: "IX_Duties_AppUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("66e83318-8faf-4efd-821b-596c9891756f"), "2cd6ca2f-d694-46f6-999e-9b69b51db46a", "user", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_AspNetUsers_AppUserId",
                table: "Duties",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duties_AspNetUsers_AppUserId",
                table: "Duties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66e83318-8faf-4efd-821b-596c9891756f"));

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Duties",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Duties_AppUserId",
                table: "Duties",
                newName: "IX_Duties_UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("8ae76496-54ed-45c2-99a2-26affc020193"), "9941b0bc-61d0-4211-ae77-5a848da48be1", "user", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Duties_AspNetUsers_UserId",
                table: "Duties",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
