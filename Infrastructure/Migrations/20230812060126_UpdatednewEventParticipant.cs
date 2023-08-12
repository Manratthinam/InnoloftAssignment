using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatednewEventParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_EventParticipant_eventid",
                table: "EventParticipant");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipant_userid",
                table: "EventParticipant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_eventid",
                table: "EventParticipant",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipant_userid",
                table: "EventParticipant",
                column: "userid");

        }
    }
}
