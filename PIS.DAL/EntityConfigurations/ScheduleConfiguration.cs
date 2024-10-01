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
    public class ScheduleConfiguration
    {
        public ScheduleConfiguration(EntityTypeBuilder<Schedule> entity)
        {
            entity.ToTable(nameof(Schedule));
            entity.HasKey(e => new { e.TrainNo, e.CurrentStation }).HasName("PK_ScheduleTrainNoCurrentStation");

            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.CurrentStation).HasDefaultValue("108");
            entity.Property(e => e.DelayStatus).HasDefaultValue("فى الموعد");
            entity.Property(e => e.Friday).HasDefaultValue(true);
            entity.Property(e => e.Saturday).HasDefaultValue(true);
            entity.Property(e => e.Sunday).HasDefaultValue(true);
            entity.Property(e => e.Monday).HasDefaultValue(true);
            entity.Property(e => e.Tuesday).HasDefaultValue(true);
            entity.Property(e => e.Wednesday).HasDefaultValue(true);
            entity.Property(e => e.Thursday).HasDefaultValue(true);
            entity.Property(e => e.Modified).HasDefaultValue(false);
            entity.Property(e => e.PlateformNo).HasDefaultValue("1");
            entity.Property(e => e.TrainNo).HasDefaultValue("2");
            entity.Property(e => e.TrainTypeAName).HasDefaultValue("طوالى");
            entity.Property(e => e.TrainTypeEName).HasDefaultValue("Direct");
            entity.Property(e => e.TrainTypeCode).HasDefaultValue("01");

            //entity.HasOne(sc => sc.TrainTrip)
            //    .WithMany(tt => tt.Schedules)
            //    .HasForeignKey(sc => sc.TrainNo)
            //    .IsRequired(false)
            //    .HasConstraintName("FK_Schedule_TrainNo");

            entity.HasOne(sc => sc.Station)
                .WithMany(tt => tt.Schedules)
                .HasForeignKey(sc => sc.CurrentStation)
                .IsRequired()
                .HasConstraintName("FK_Schedule_CurrentStation");
        }
    }
}
