using Microsoft.EntityFrameworkCore.Migrations;

namespace api_test.Migrations
{
    public partial class AddForeignKeyinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_Userid",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Userid",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Post");

            migrationBuilder.CreateIndex(
                name: "IX_Post_author_id",
                table: "Post",
                column: "author_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_author_id",
                table: "Post",
                column: "author_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_author_id",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_author_id",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_Userid",
                table: "Post",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_Userid",
                table: "Post",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
