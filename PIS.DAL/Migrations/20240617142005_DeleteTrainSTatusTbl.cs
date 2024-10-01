using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class DeleteTrainSTatusTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Train_Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Train_Status",
                columns: table => new
                {
                    StatusID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    StatusEnSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "On Time"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train_Status", x => x.StatusID);
                });
        }
    }
}
