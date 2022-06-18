using Microsoft.EntityFrameworkCore.Migrations;

namespace entity_framework.Migrations
{
    public partial class ProfileToyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileToy",
                table: "ProfileToy");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProfileToy",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileToy",
                table: "ProfileToy",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileToy_ProfilesId",
                table: "ProfileToy",
                column: "ProfilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileToy",
                table: "ProfileToy");

            migrationBuilder.DropIndex(
                name: "IX_ProfileToy_ProfilesId",
                table: "ProfileToy");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfileToy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileToy",
                table: "ProfileToy",
                columns: new[] { "ProfilesId", "ToysId" });
        }
    }
}
