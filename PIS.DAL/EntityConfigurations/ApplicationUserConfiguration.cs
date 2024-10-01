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
    public class ApplicationUserConfiguration
    {
        public ApplicationUserConfiguration(EntityTypeBuilder<ApplicationUser> entity)
        {
            entity.ToTable("ApplicationUser");
            entity.HasKey(e => e.Id).HasName("PK_ApplicationUser");
            entity.Property(e => e.audDateLastChanged).HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.LastModified).HasDefaultValueSql("GETDATE()");
        }
    }
}
