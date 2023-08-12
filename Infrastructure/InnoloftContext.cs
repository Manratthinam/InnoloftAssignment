using Domain.DbEntities.Event;
using Domain.DbEntities.EventParticipants;
using Domain.DbEntities.User;
using Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InnoloftContext : DbContext
    {
        public InnoloftContext(DbContextOptions<InnoloftContext> options) : base(options) { }
            
        public DbSet<Users> User { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(null);
            modelBuilder.ApplyAllConfiguration();
            foreach (var item in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetProperties()))
            {
                item.SetColumnName(item.Name.ToLower());
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
