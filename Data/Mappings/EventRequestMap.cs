
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class EventRequestMap : EntityTypeConfiguration<EventRequest>
    {
        public EventRequestMap()
        {
            // Table 
            ToTable("EventRequest", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Status)
                .IsRequired();

            Property(c => c.Details)
                .IsOptional();

            // navigational properties
            HasRequired(x => x.Event)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.EventId);

            HasRequired(x => x.Performer)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.PerformerId);

            HasMany(x => x.Negotiations)
                .WithRequired(x => x.EventRequest)
                .HasForeignKey(x => x.EventRequestId);
        }
    }
}
