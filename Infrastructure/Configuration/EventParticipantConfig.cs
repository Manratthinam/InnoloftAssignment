using Domain.DbEntities.EventParticipants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class EventParticipantConfig : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.ToTable("EventParticipant");
            builder.HasOne(x => x.User)
            .WithMany(x => x.ParticipatedEvents);

            builder.HasOne(ap => ap.Event)
                .WithMany(x => x.EventParticipant);
                
            builder.HasKey(x => x.Id);

        }
    }
}
