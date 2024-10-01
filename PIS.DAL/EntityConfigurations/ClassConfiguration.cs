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
    public class ClassConfiguration
    {
        public ClassConfiguration(EntityTypeBuilder<Class> entity)
        {
            entity.ToTable(nameof(Class));
            entity.HasKey(e => e.ClassCode).HasName("PK_Class");
            entity.Property(e => e.ClassAName);
            entity.Property(e => e.ClassEName);
            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
        }
    }
}
