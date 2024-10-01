using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class deletebehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainTripRout_TrainNo",
                table: "TrainTripRout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_TrainTripRout_TrainNo",
                table: "TrainTripRout",
                column: "TrainNo",
                principalTable: "Train_Trip",
                principalColumn: "TrainNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
