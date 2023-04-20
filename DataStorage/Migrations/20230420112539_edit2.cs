using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStorage.Migrations
{
    /// <inheritdoc />
    public partial class edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Books_BookId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_BookId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                column: "BookId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                column: "BookId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Members_BookId",
                table: "Members",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Books_BookId",
                table: "Members",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
