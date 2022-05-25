using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework.Migrations
{
    public partial class FixedRelatioImagesProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_profiles_ProfileId",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_images_ProfileId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "images");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_ImageId",
                table: "profiles",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_images_ImageId",
                table: "profiles",
                column: "ImageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_images_ImageId",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_ImageId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_images_ProfileId",
                table: "images",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_images_profiles_ProfileId",
                table: "images",
                column: "ProfileId",
                principalTable: "profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
