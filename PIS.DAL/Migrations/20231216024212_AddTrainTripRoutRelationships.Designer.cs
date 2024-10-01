﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIS.DAL;

#nullable disable

namespace PIS.DAL.Migrations
{
    [DbContext(typeof(PISContext))]
    [Migration("20231216024212_AddTrainTripRoutRelationships")]
    partial class AddTrainTripRoutRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PIS.Models.Class", b =>
                {
                    b.Property<string>("ClassCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassAName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassEName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 847, DateTimeKind.Local).AddTicks(1281));

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 847, DateTimeKind.Local).AddTicks(956));

                    b.HasKey("ClassCode")
                        .HasName("PK_Class");

                    b.ToTable("Class", (string)null);
                });

            modelBuilder.Entity("PIS.Models.Schedule", b =>
                {
                    b.Property<string>("TrainNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("2");

                    b.Property<string>("CurrentStation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("108");

                    b.Property<string>("A_Journy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Class0AName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class0Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class0EName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class1AName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class1Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class1EName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DelayReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DelayStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("فى الموعد");

                    b.Property<DateTime?>("DeptTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("E_Journy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalStationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Friday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool?>("Monday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("PlateformNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("1");

                    b.Property<bool?>("Saturday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("StartStationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("StationOrder")
                        .HasColumnType("float");

                    b.Property<bool?>("Sunday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool?>("Thursday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("TrainTypeAName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("طوالى");

                    b.Property<string>("TrainTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("01");

                    b.Property<string>("TrainTypeEName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Direct");

                    b.Property<bool?>("Tuesday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool?>("Wednesday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 847, DateTimeKind.Local).AddTicks(3318));

                    b.HasKey("TrainNo", "CurrentStation")
                        .HasName("PK_ScheduleTrainNoCurrentStation");

                    b.HasIndex("CurrentStation");

                    b.ToTable("Schedule", (string)null);
                });

            modelBuilder.Entity("PIS.Models.station", b =>
                {
                    b.Property<string>("StationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 849, DateTimeKind.Local).AddTicks(2540));

                    b.Property<string>("NameArb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEngl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 849, DateTimeKind.Local).AddTicks(2132));

                    b.HasKey("StationCode")
                        .HasName("PK_stations");

                    b.ToTable("stations", (string)null);
                });

            modelBuilder.Entity("PIS.Models.Train_Delay_Reson", b =>
                {
                    b.Property<string>("ResonName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 849, DateTimeKind.Local).AddTicks(3895));

                    b.Property<decimal>("ResonID")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 849, DateTimeKind.Local).AddTicks(3588));

                    b.HasKey("ResonName")
                        .HasName("PK_Train_Delay_Reson");

                    b.ToTable("Train_Delay_Reson", (string)null);
                });

            modelBuilder.Entity("PIS.Models.Train_Status", b =>
                {
                    b.Property<decimal>("StatusID")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 849, DateTimeKind.Local).AddTicks(6494));

                    b.Property<string>("StatusEnSymbol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("On Time");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 849, DateTimeKind.Local).AddTicks(6178));

                    b.HasKey("StatusID")
                        .HasName("PK_Train_Status");

                    b.ToTable("Train_Status", (string)null);
                });

            modelBuilder.Entity("PIS.Models.Train_Trip", b =>
                {
                    b.Property<string>("TrainNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassCode1")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("1U");

                    b.Property<string>("ClassCode2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("2U");

                    b.Property<bool>("Friday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 850, DateTimeKind.Local).AddTicks(6913));

                    b.Property<bool>("Monday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("Saturday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("Sunday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("Thursday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("TrainType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("01");

                    b.Property<bool>("Tuesday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("Wednesday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 850, DateTimeKind.Local).AddTicks(4119));

                    b.HasKey("TrainNo")
                        .HasName("PK_V_Train_Trip");

                    b.HasIndex("ClassCode1");

                    b.HasIndex("ClassCode2");

                    b.HasIndex("TrainType");

                    b.ToTable("Train_Trip", (string)null);
                });

            modelBuilder.Entity("PIS.Models.Train_Type", b =>
                {
                    b.Property<string>("TrainType")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 855, DateTimeKind.Local).AddTicks(6155));

                    b.Property<string>("TrainTypeDescArb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainTypeDescEngl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 855, DateTimeKind.Local).AddTicks(5685));

                    b.HasKey("TrainType")
                        .HasName("PK_Train_Type");

                    b.ToTable("Train_Type", (string)null);
                });

            modelBuilder.Entity("PIS.Models.TrainTripRout", b =>
                {
                    b.Property<string>("TrainNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeptTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 855, DateTimeKind.Local).AddTicks(8871));

                    b.Property<double?>("OrderNumber")
                        .HasColumnType("float");

                    b.Property<string>("PlateformNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("-");

                    b.Property<DateTime?>("audDateLastChanged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 16, 4, 42, 10, 855, DateTimeKind.Local).AddTicks(8549));

                    b.HasKey("TrainNo", "StationCode")
                        .HasName("PK_TrainTripRout");

                    b.HasIndex("StationCode");

                    b.ToTable("TrainTripRout", (string)null);
                });

            modelBuilder.Entity("PIS.Models.Schedule", b =>
                {
                    b.HasOne("PIS.Models.station", "Station")
                        .WithMany("Schedules")
                        .HasForeignKey("CurrentStation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Schedule_CurrentStation");

                    b.HasOne("PIS.Models.Train_Trip", "TrainTrip")
                        .WithMany("Schedules")
                        .HasForeignKey("TrainNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Schedule_TrainNo");

                    b.Navigation("Station");

                    b.Navigation("TrainTrip");
                });

            modelBuilder.Entity("PIS.Models.Train_Trip", b =>
                {
                    b.HasOne("PIS.Models.Class", "Class1")
                        .WithMany("Class1TrainTrips")
                        .HasForeignKey("ClassCode1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Train_Trip_ClassCode1");

                    b.HasOne("PIS.Models.Class", "Class2")
                        .WithMany("Class2TrainTrips")
                        .HasForeignKey("ClassCode2")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Train_Trip_ClassCode2");

                    b.HasOne("PIS.Models.Train_Type", "Train_Type")
                        .WithMany("TrainTrips")
                        .HasForeignKey("TrainType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Train_Trip_TrainType");

                    b.Navigation("Class1");

                    b.Navigation("Class2");

                    b.Navigation("Train_Type");
                });

            modelBuilder.Entity("PIS.Models.TrainTripRout", b =>
                {
                    b.HasOne("PIS.Models.station", "Station")
                        .WithMany("TrainTripRouts")
                        .HasForeignKey("StationCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TrainTripRout_StationCode");

                    b.HasOne("PIS.Models.Train_Trip", "Train_Trip")
                        .WithMany("TrainTripRouts")
                        .HasForeignKey("TrainNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TrainTripRout_TrainNo");

                    b.Navigation("Station");

                    b.Navigation("Train_Trip");
                });

            modelBuilder.Entity("PIS.Models.Class", b =>
                {
                    b.Navigation("Class1TrainTrips");

                    b.Navigation("Class2TrainTrips");
                });

            modelBuilder.Entity("PIS.Models.station", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("TrainTripRouts");
                });

            modelBuilder.Entity("PIS.Models.Train_Trip", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("TrainTripRouts");
                });

            modelBuilder.Entity("PIS.Models.Train_Type", b =>
                {
                    b.Navigation("TrainTrips");
                });
#pragma warning restore 612, 618
        }
    }
}
