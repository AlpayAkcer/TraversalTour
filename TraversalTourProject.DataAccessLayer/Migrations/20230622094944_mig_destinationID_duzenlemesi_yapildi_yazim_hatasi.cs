using Microsoft.EntityFrameworkCore.Migrations;

namespace TraversalTourProject.DataAccessLayer.Migrations
{
    public partial class mig_destinationID_duzenlemesi_yapildi_yazim_hatasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DestionationID",
                table: "Destinations",
                newName: "DestinationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "Destinations",
                newName: "DestionationID");
        }
    }
}
