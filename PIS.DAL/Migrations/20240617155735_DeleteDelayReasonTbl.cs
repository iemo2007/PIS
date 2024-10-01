using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class DeleteDelayReasonTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Train_Delay_Reson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Train_Delay_Reson",
                columns: table => new
                {
                    ResonName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ResonID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train_Delay_Reson", x => x.ResonName);
                });
        }
    }
}
