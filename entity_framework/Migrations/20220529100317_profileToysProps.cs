using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework.Migrations
{
    public partial class profileToysProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_toys_ToyId",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_images_ToyId",
                table: "images");

            migrationBuilder.DropColumn(
                name: "ToyId",
                table: "images");

            migrationBuilder.CreateTable(
                name: "ImageToy",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    ToysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageToy", x => new { x.ImagesId, x.ToysId });
                    table.ForeignKey(
                        name: "FK_ImageToy_images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageToy_toys_ToysId",
                        column: x => x.ToysId,
                        principalTable: "toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileToy",
                columns: table => new
                {
                    ProfilesId = table.Column<int>(type: "int", nullable: false),
                    ToysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileToy", x => new { x.ProfilesId, x.ToysId });
                    table.ForeignKey(
                        name: "FK_ProfileToy_profiles_ProfilesId",
                        column: x => x.ProfilesId,
                        principalTable: "profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileToy_toys_ToysId",
                        column: x => x.ToysId,
                        principalTable: "toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageToy_ToysId",
                table: "ImageToy",
                column: "ToysId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileToy_ToysId",
                table: "ProfileToy",
                column: "ToysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageToy");

            migrationBuilder.DropTable(
                name: "ProfileToy");

            migrationBuilder.AddColumn<int>(
                name: "ToyId",
                table: "images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_images_ToyId",
                table: "images",
                column: "ToyId");

            migrationBuilder.AddForeignKey(
                name: "FK_images_toys_ToyId",
                table: "images",
                column: "ToyId",
                principalTable: "toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
