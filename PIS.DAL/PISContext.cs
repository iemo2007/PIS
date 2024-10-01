using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PIS.DAL.EntityConfigurations;
using PIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PIS.DAL
{
    public class PISContext : IdentityDbContext<ApplicationUser>
    {
        public PISContext(DbContextOptions<PISContext> options) : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<station> stations { get; set; }
        public DbSet<Train_Delay_Reson> Train_Delay_Reson { get; set; }
        public DbSet<Train_Status> Train_Status { get; set; }
        public DbSet<Train_Trip> Train_Trip { get; set; }
        public DbSet<Train_Type> Train_Type { get; set; }
        public DbSet<TrainTripRout> TrainTripRouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ClassConfiguration(modelBuilder.Entity<Class>());
            new ScheduleConfiguration(modelBuilder.Entity<Schedule>());
            new StationConfiguration(modelBuilder.Entity<station>());
            new Train_Delay_ResonConfiguration(modelBuilder.Entity<Train_Delay_Reson>());
            new Train_StatusConfiguration(modelBuilder.Entity<Train_Status>());
            new Train_TripConfiguration(modelBuilder.Entity<Train_Trip>());
            new Train_TypeConfiguration(modelBuilder.Entity<Train_Type>());
            new TrainTripRoutConfiguration(modelBuilder.Entity<TrainTripRout>());
            new ApplicationUserConfiguration(modelBuilder.Entity<ApplicationUser>());

        }

        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified)
                {
                    try
                    {
                        PropertyEntry lastModefiedProperty = entry.Property("LastModified");
                        if (lastModefiedProperty != null)
                        {
                            entry.Property("LastModified").CurrentValue = DateTime.Now;
                        }
                    }
                    catch { }

                    try
                    {
                        PropertyEntry modefiedProperty = entry.Property("Modified");
                        // PropertyEntry modifiedProperty = entry.Property("Modified");
                        if (modefiedProperty != null)
                        {
                            entry.Property("Modified").CurrentValue = DateTime.Now;
                        }
                    }
                    catch { }

                    PropertyEntry audDateLastChanged = entry.Property("audDateLastChanged");
                    if (audDateLastChanged != null)
                    {
                        entry.Property("audDateLastChanged").CurrentValue = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}
