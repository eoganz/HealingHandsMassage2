using Microsoft.EntityFrameworkCore.Migrations;

namespace HealingHandsMassage.Data.Migrations
{
    public partial class RemovedImgPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_carouselItems",
                table: "carouselItems");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "carouselItems");

            migrationBuilder.RenameTable(
                name: "carouselItems",
                newName: "CarouselItems");

            migrationBuilder.RenameColumn(
                name: "TextInJson",
                table: "CarouselItems",
                newName: "Text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarouselItems",
                table: "CarouselItems",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarouselItems",
                table: "CarouselItems");

            migrationBuilder.RenameTable(
                name: "CarouselItems",
                newName: "carouselItems");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "carouselItems",
                newName: "TextInJson");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "carouselItems",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_carouselItems",
                table: "carouselItems",
                column: "id");
        }
    }
}
