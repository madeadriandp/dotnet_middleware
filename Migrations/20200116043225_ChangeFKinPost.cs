using Microsoft.EntityFrameworkCore.Migrations;

namespace api_test.Migrations
{
    public partial class ChangeFKinPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_post_id",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_post_id",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "post_id",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_post_id",
                table: "Comments",
                column: "post_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_post_id",
                table: "Comments",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_post_id",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_post_id",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "post_id",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_post_id",
                table: "Posts",
                column: "post_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_post_id",
                table: "Posts",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
