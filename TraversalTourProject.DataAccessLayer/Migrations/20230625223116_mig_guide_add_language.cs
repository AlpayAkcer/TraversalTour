using Microsoft.EntityFrameworkCore.Migrations;

namespace TraversalTourProject.DataAccessLayer.Migrations
{
    public partial class mig_guide_add_language : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Guides",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Guides");
        }
    }
}
