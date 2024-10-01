using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class DeleteRelationScheduleTrainTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_TrainNo",
                table: "Schedule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_TrainNo",
                table: "Schedule",
                column: "TrainNo",
                principalTable: "Train_Trip",
                principalColumn: "TrainNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
