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
    public class Train_Delay_ResonConfiguration
    {
        public Train_Delay_ResonConfiguration(EntityTypeBuilder<Train_Delay_Reson> entity)
        {
            entity.ToTable(nameof(Train_Delay_Reson));
            entity.HasKey(e => e.ResonID).HasName("PK_Train_Delay_Reson");
            entity.Property(e => e.ResonID).ValueGeneratedOnAdd();
            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
        }
    }
}
