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
    public class Train_TypeConfiguration
    {
        public Train_TypeConfiguration(EntityTypeBuilder<Train_Type> entity)
        {
            entity.ToTable(nameof(Train_Type));
            entity.HasKey(e => e.TrainType).HasName("PK_Train_Type");
            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
        }
    }
}
