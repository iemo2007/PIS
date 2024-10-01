using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL.EntityConfigurations
{
    public class TrainTripRoutConfiguration
    {
        public TrainTripRoutConfiguration(EntityTypeBuilder<TrainTripRout> entity)
        {
            entity.ToTable(nameof(TrainTripRout));
            entity.HasKey(e => new { e.TrainNo, e.StationCode }).HasName("PK_TrainTripRout");
            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.PlateformNo).HasDefaultValue("-");

            //entity.HasOne(ttr => ttr.Train_Trip)
            //    .WithMany(tt => tt.TrainTripRouts)
            //    .HasForeignKey(ttr => ttr.TrainNo)
            //    .HasConstraintName("FK_TrainTripRout_TrainNo")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.ClientNoAction);

            entity.HasOne(ttr => ttr.Station)
                .WithMany(s => s.TrainTripRouts)
                .HasForeignKey(ttr => ttr.StationCode)
                .HasConstraintName("FK_TrainTripRout_StationCode")
                .IsRequired();
        }
    }
}
