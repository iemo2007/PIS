using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class Initial : Migration 
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassEName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassAName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 244, DateTimeKind.Local).AddTicks(9105)),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 244, DateTimeKind.Local).AddTicks(8694))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassCode);
                });

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    StationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameArb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEngl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 247, DateTimeKind.Local).AddTicks(2677)),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 247, DateTimeKind.Local).AddTicks(2327))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.StationCode);
                });

            migrationBuilder.CreateTable(
                name: "Train_Delay_Reson",
                columns: table => new
                {
                    ResonName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResonID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 247, DateTimeKind.Local).AddTicks(4341)),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 247, DateTimeKind.Local).AddTicks(4068))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train_Delay_Reson", x => x.ResonName);
                });

            migrationBuilder.CreateTable(
                name: "Train_Status",
                columns: table => new
                {
                    StatusID = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusEnSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "On Time"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 247, DateTimeKind.Local).AddTicks(5747)),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 247, DateTimeKind.Local).AddTicks(5466))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Train_Type",
                columns: table => new
                {
                    TrainType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainTypeDescEngl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainTypeDescArb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 252, DateTimeKind.Local).AddTicks(4430)),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 252, DateTimeKind.Local).AddTicks(4116))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Train_Type", x => x.TrainType);
                });

            migrationBuilder.CreateTable(
                name: "Train_Trip",
                columns: table => new
                {
                    TrainNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainType = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "01"),
                    ClassCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "1U"),
                    ClassCode2 = table.Column<string>(type: "nvarchar(450)", nullable: true, defaultValue: "2U"),
                    Saturday = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Sunday = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Monday = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Thursday = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Friday = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 248, DateTimeKind.Local).AddTicks(4903)),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 248, DateTimeKind.Local).AddTicks(2630))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Train_Trip", x => x.TrainNo);
                    table.ForeignKey(
                        name: "FK_Train_Trip_ClassCode1",
                        column: x => x.ClassCode1,
                        principalTable: "Class",
                        principalColumn: "ClassCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Train_Trip_ClassCode2",
                        column: x => x.ClassCode2,
                        principalTable: "Class",
                        principalColumn: "ClassCode");
                    table.ForeignKey(
                        name: "FK_Train_Trip_TrainType",
                        column: x => x.TrainType,
                        principalTable: "Train_Type",
                        principalColumn: "TrainType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    TrainNo = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "2"),
                    CurrentStation = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "108"),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeptTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartStationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalStationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_Journy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    A_Journy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class0Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class0EName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class0AName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class1Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class1EName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class1AName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "01"),
                    TrainTypeEName = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Direct"),
                    TrainTypeAName = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "طوالى"),
                    PlateformNo = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1"),
                    DelayStatus = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "فى الموعد"),
                    Saturday = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Sunday = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Monday = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Tuesday = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Wednesday = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Thursday = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Friday = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    StationOrder = table.Column<double>(type: "float", nullable: true),
                    Modified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 245, DateTimeKind.Local).AddTicks(1363)),
                    DelayReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleTrainNoCurrentStation", x => new { x.TrainNo, x.CurrentStation });
                    table.ForeignKey(
                        name: "FK_Schedule_CurrentStation",
                        column: x => x.CurrentStation,
                        principalTable: "stations",
                        principalColumn: "StationCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_TrainNo",
                        column: x => x.TrainNo,
                        principalTable: "Train_Trip",
                        principalColumn: "TrainNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainTripRout",
                columns: table => new
                {
                    TrainNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeptTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNumber = table.Column<double>(type: "float", nullable: true),
                    PlateformNo = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "-"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 252, DateTimeKind.Local).AddTicks(6742)),
                    audDateLastChanged = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 9, 16, 18, 27, 0, 252, DateTimeKind.Local).AddTicks(6441)),
                    Train_TripTrainNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StationCode1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainTripRout", x => new { x.TrainNo, x.StationCode });
                    table.ForeignKey(
                        name: "FK_TrainTripRout_stations_StationCode1",
                        column: x => x.StationCode1,
                        principalTable: "stations",
                        principalColumn: "StationCode");
                    table.ForeignKey(
                        name: "FK_TrainTripRout_Train_Trip_Train_TripTrainNo",
                        column: x => x.Train_TripTrainNo,
                        principalTable: "Train_Trip",
                        principalColumn: "TrainNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_CurrentStation",
                table: "Schedule",
                column: "CurrentStation");

            migrationBuilder.CreateIndex(
                name: "IX_Train_Trip_ClassCode1",
                table: "Train_Trip",
                column: "ClassCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Train_Trip_ClassCode2",
                table: "Train_Trip",
                column: "ClassCode2");

            migrationBuilder.CreateIndex(
                name: "IX_Train_Trip_TrainType",
                table: "Train_Trip",
                column: "TrainType");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTripRout_StationCode1",
                table: "TrainTripRout",
                column: "StationCode1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTripRout_Train_TripTrainNo",
                table: "TrainTripRout",
                column: "Train_TripTrainNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Train_Delay_Reson");

            migrationBuilder.DropTable(
                name: "Train_Status");

            migrationBuilder.DropTable(
                name: "TrainTripRout");

            migrationBuilder.DropTable(
                name: "stations");

            migrationBuilder.DropTable(
                name: "Train_Trip");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Train_Type");
        }
    }
}
