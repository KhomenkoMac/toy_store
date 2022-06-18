using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework.Migrations
{
    public partial class manyProfilesForImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_profiles_ImageId",
                table: "profiles");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_ImageId",
                table: "profiles",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_profiles_ImageId",
                table: "profiles");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_ImageId",
                table: "profiles",
                column: "ImageId",
                unique: true);
        }
    }
}
