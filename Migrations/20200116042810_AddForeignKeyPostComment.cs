using Microsoft.EntityFrameworkCore.Migrations;

namespace api_test.Migrations
{
    public partial class AddForeignKeyPostComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_author_id",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_Post_author_id",
                table: "Posts",
                newName: "IX_Posts_author_id");

            migrationBuilder.AddColumn<int>(
                name: "post_id",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_post_id",
                table: "Posts",
                column: "post_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_author_id",
                table: "Posts",
                column: "author_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_post_id",
                table: "Posts",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_author_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_post_id",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_post_id",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "post_id",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_author_id",
                table: "Post",
                newName: "IX_Post_author_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_author_id",
                table: "Post",
                column: "author_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
