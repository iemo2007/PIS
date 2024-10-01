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
    public class StationConfiguration
    {
        public StationConfiguration(EntityTypeBuilder<station> entity)
        {
            entity.ToTable("stations");
            entity.HasKey(e => e.StationCode).HasName("PK_stations");
            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
        }
    }
}
