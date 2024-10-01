using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIS.DAL.Migrations
{
    public partial class SP_Reset_Train_Trip_Table_TrainNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
    CREATE PROCEDURE [dbo].[Reset_Train_Trip_Table_TrainNumber]
        @TrainNo AS nvarchar(10)
    AS
    BEGIN
        DELETE [Train_Trip] WHERE TrainNo = @TrainNo

        INSERT INTO [Train_Trip] (TrainNo, StartStation, DepartureTime, FinalStation, ArrivalTime)
        SELECT DISTINCT TTR1.TrainNo as TrainNo, 
        TTR1.StationCode AS StartStation, 
        Convert(nvarchar, TTR1.DeptTime, 8) AS DepartureTime, 
        TTR2.StationCode AS FinalStation,
        Convert(nvarchar, TTR2.ArrivalTime, 8) AS ArrivalTime
        FROM TrainTripRout AS TTR1, TrainTripRout AS TTR2
        WHERE TTR1.OrderNumber=1
        AND TTR2.TrainNo=TTR1.TrainNo
        AND TTR1.TrainNo = @TrainNo
        AND TTR2.OrderNumber=(SELECT MAX(OrderNumber) FROM TrainTripRout WHERE TrainTripRout.TrainNo=TTR2.TrainNo);

        INSERT INTO [Schedule] (TrainNo, CurrentStation, ArrivalTime, DeptTime, StartStationCode, FinalStationCode, E_Journy, A_Journy, PlateformNo, Class0Code, Class0EName, Class0AName,  Class1Code, Class1EName, Class1AName, TrainTypeCode, TrainTypeEName, TrainTypeAName, [StationOrder],[Saturday],[Sunday],[Monday],[Tuesday],[Wednesday],[Thursday],[Friday])
        SELECT Distinct
        [TrainTripRout].TrainNo,
        [TrainTripRout].[StationCode] as [CurrentStation],
        [TrainTripRout].[ArrivalTime] as [ArrivalTime],
        [TrainTripRout].DeptTime as [DeptTime],
        [Train_Trip].[StartStation] as [StartStationCode],
        [Train_Trip].[FinalStation] as [FinalStationCode],
        [Station_1].[NameEngl] + ' - ' + [Station_2].[NameEngl] as [E_Journy],
        [Station_1].[NameArb] + ' - ' + [Station_2].[NameArb] as [A_Journy],
        [TrainTripRout].[PlateformNo] as [PlateformNo],
        [Class_1].[ClassCode] as [Class0Code],
        [Class_1].[ClassEName] as [Class0EName],
        [Class_1].[ClassAName] as [Class0AName],
        [Class_2].[ClassCode] as [Class1Code], 
        [Class_2].[ClassEName] as [Class1EName],
        [Class_2].[ClassAName] as [Class1AName],
        [Train_Type].[TrainType] as [TrainTypeCode],
        [Train_Type].[TrainTypeDescEngl] as [TrainTypeEName],
        [Train_Type].[TrainTypeDescArb] as [TrainTypeAName],
        [TrainTripRout].[OrderNumber] as [StationOrder],
        [Train_Trip].[Saturday],
        [Train_Trip].[Sunday],
        [Train_Trip].[Monday],
        [Train_Trip].[Tuesday],
        [Train_Trip].[Wednesday],
        [Train_Trip].[Thursday],
        [Train_Trip].[Friday]
        FROM 
        TrainTripRout, 
        Train_Trip, 
        Stations, 
        Stations AS Station_1, 
        Stations AS Station_2, 
        Class as Class_2, 
        Class AS Class_1, 
        Train_Type
        WHERE TrainTripRout.TrainNo = Train_Trip.TrainNo
        AND Train_Trip.ClassCode2 = Class_1.ClassCode
        AND Train_Trip.ClassCode1 = Class_2.ClassCode
        AND Train_Trip.StartStation = Station_1.StationCode
        AND Train_Trip.FinalStation = Station_2.StationCode
        AND Train_Trip.[TrainType] = Train_Type.[TrainType]
        AND TrainTripRout.StationCode = Stations.StationCode
        AND Train_Trip.TrainNo = @TrainNo
    END";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string dropProcedure = "DROP PROCEDURE [dbo].[Reset_Train_Trip_Table_TrainNumber]";
            migrationBuilder.Sql(dropProcedure);
        }
    }
}
