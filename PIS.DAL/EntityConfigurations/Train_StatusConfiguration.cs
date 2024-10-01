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
    public class Train_StatusConfiguration
    {
        public Train_StatusConfiguration(EntityTypeBuilder<Train_Status> entity)
        {
            entity.ToTable(nameof(Train_Status));
            entity.HasKey(e => e.StatusID).HasName("PK_Train_Status");
            entity.Property(e => e.StatusID).ValueGeneratedOnAdd();
            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.StatusEnSymbol).HasDefaultValue("On Time");
        }
    }
}
