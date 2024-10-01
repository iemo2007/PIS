using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class AddTrainTripRoutRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainTripRout_stations_StationCode1",
                table: "TrainTripRout");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTripRout_Train_Trip_Train_TripTrainNo",
                table: "TrainTripRout");

            migrationBuilder.DropIndex(
                name: "IX_TrainTripRout_StationCode1",
                table: "TrainTripRout");

            migrationBuilder.DropIndex(
                name: "IX_TrainTripRout_Train_TripTrainNo",
                table: "TrainTripRout");

            migrationBuilder.DropColumn(
                name: "StationCode1",
                table: "TrainTripRout");

            migrationBuilder.DropColumn(
                name: "Train_TripTrainNo",
                table: "TrainTripRout");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTripRout_StationCode",
                table: "TrainTripRout",
                column: "StationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTripRout_StationCode",
                table: "TrainTripRout",
                column: "StationCode",
                principalTable: "stations",
                principalColumn: "StationCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTripRout_TrainNo",
                table: "TrainTripRout",
                column: "TrainNo",
                principalTable: "Train_Trip",
                principalColumn: "TrainNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainTripRout_StationCode",
                table: "TrainTripRout");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainTripRout_TrainNo",
                table: "TrainTripRout");

            migrationBuilder.DropIndex(
                name: "IX_TrainTripRout_StationCode",
                table: "TrainTripRout");

            

            migrationBuilder.AddColumn<string>(
                name: "StationCode1",
                table: "TrainTripRout",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Train_TripTrainNo",
                table: "TrainTripRout",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainTripRout_StationCode1",
                table: "TrainTripRout",
                column: "StationCode1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTripRout_Train_TripTrainNo",
                table: "TrainTripRout",
                column: "Train_TripTrainNo");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTripRout_stations_StationCode1",
                table: "TrainTripRout",
                column: "StationCode1",
                principalTable: "stations",
                principalColumn: "StationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainTripRout_Train_Trip_Train_TripTrainNo",
                table: "TrainTripRout",
                column: "Train_TripTrainNo",
                principalTable: "Train_Trip",
                principalColumn: "TrainNo");
        }
    }
}
