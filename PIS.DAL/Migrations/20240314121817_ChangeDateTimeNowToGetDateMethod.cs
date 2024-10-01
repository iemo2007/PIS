using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class ChangeDateTimeNowToGetDateMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "TrainTripRout",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "TrainTripRout",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Type",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Type",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Trip",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 849, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Trip",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 849, DateTimeKind.Local).AddTicks(3373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Status",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(3859));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Status",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Delay_Reson",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Delay_Reson",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "stations",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "stations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Schedule",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 845, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Class",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 845, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Class",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 845, DateTimeKind.Local).AddTicks(7432));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "TrainTripRout",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(8890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "TrainTripRout",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(9202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Type",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(6694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Type",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 858, DateTimeKind.Local).AddTicks(7052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Trip",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 849, DateTimeKind.Local).AddTicks(686),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 849, DateTimeKind.Local).AddTicks(3373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Status",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(3859),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(4131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Train_Delay_Reson",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(2327),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Train_Delay_Reson",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(2590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "stations",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(633),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "stations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 848, DateTimeKind.Local).AddTicks(986),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Schedule",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 845, DateTimeKind.Local).AddTicks(9826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "audDateLastChanged",
                table: "Class",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 845, DateTimeKind.Local).AddTicks(7021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Class",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 10, 17, 25, 845, DateTimeKind.Local).AddTicks(7432),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
