using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.EntityConfigurations
{
    public class Train_TripConfiguration
    {
        public Train_TripConfiguration(EntityTypeBuilder<Train_Trip> entity)
        {
            entity.ToTable(nameof(Train_Trip));
            entity.HasKey(e => e.TrainNo).HasName("PK_V_Train_Trip");

            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.ClassCode1).HasDefaultValue("1U");
            entity.Property(e => e.ClassCode2).HasDefaultValue("2U");
            entity.Property(e => e.Friday).HasDefaultValue(true);
            entity.Property(e => e.Saturday).HasDefaultValue(true);
            entity.Property(e => e.Sunday).HasDefaultValue(true);
            entity.Property(e => e.Monday).HasDefaultValue(true);
            entity.Property(e => e.Tuesday).HasDefaultValue(true);
            entity.Property(e => e.Wednesday).HasDefaultValue(true);
            entity.Property(e => e.Thursday).HasDefaultValue(true);
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.TrainType).HasDefaultValue("01");

            entity.Ignore(e => e.StartStation);
            // entity.Ignore(e => e.DepartureTime);
            entity.Ignore(e => e.FinalStation);
            // entity.Ignore(e => e.ArrivalTime);

            entity.HasOne(tt => tt.StartStationObj)
                .WithMany(s => s.TrainTripsStart)
                .HasForeignKey(tt => tt.StartStation)
                .IsRequired()
                .HasConstraintName("FK_Train_Trip_StartStation")
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(tt => tt.FinalStationObj)
                .WithMany(s => s.TrainTripsFinal)
                .HasForeignKey(tt => tt.FinalStation)
                .IsRequired()
                .HasConstraintName("FK_Train_Trip_FinalStation")
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(tt => tt.Class1)
                .WithMany(s => s.Class1TrainTrips)
                .HasForeignKey(tt => tt.ClassCode1)
                .IsRequired()
                .HasConstraintName("FK_Train_Trip_ClassCode1");

            entity.HasOne(tt => tt.Class2)
                .WithMany(s => s.Class2TrainTrips)
                .HasForeignKey(tt => tt.ClassCode2)
                .HasConstraintName("FK_Train_Trip_ClassCode2")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(tt => tt.Train_Type)
                .WithMany(s => s.TrainTrips)
                .HasForeignKey(tt => tt.TrainType)
                .IsRequired()
                .HasConstraintName("FK_Train_Trip_TrainType");
        }
    }
}
