using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class AddStartAndFinalStationFKToTrainTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinalStation",
                table: "Train_Trip",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartStation",
                table: "Train_Trip",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Train_Trip_FinalStation",
                table: "Train_Trip",
                column: "FinalStation");

            migrationBuilder.CreateIndex(
                name: "IX_Train_Trip_StartStation",
                table: "Train_Trip",
                column: "StartStation");

            migrationBuilder.AddForeignKey(
                name: "FK_Train_Trip_FinalStation",
                table: "Train_Trip",
                column: "FinalStation",
                principalTable: "stations",
                principalColumn: "StationCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Train_Trip_StartStation",
                table: "Train_Trip",
                column: "StartStation",
                principalTable: "stations",
                principalColumn: "StationCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Train_Trip_FinalStation",
                table: "Train_Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Train_Trip_StartStation",
                table: "Train_Trip");

            migrationBuilder.DropIndex(
                name: "IX_Train_Trip_FinalStation",
                table: "Train_Trip");

            migrationBuilder.DropIndex(
                name: "IX_Train_Trip_StartStation",
                table: "Train_Trip");

            migrationBuilder.DropColumn(
                name: "FinalStation",
                table: "Train_Trip");

            migrationBuilder.DropColumn(
                name: "StartStation",
                table: "Train_Trip");
        }
    }
}
