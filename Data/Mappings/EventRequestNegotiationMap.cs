
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class EventRequestNegotiationMap : EntityTypeConfiguration<EventRequestNegotiation>
    {
        public EventRequestNegotiationMap()
        {
            // Table 
            ToTable("EventRequestNegotiation", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Fee)
                .IsRequired();

            Property(c => c.Period)
                .IsRequired();

            Property(c => c.PerformerAgrees)
                .IsRequired();

            Property(c => c.OrganizationAgrees)
                .IsRequired();

            Property(c => c.DateSent)
                .IsOptional()
                .HasColumnType("date");

            Property(c => c.DateAgreed)
                .IsOptional()
                .HasColumnType("date");

            Property(c => c.CancellationDate)
                .IsOptional()
                .HasColumnType("date");

            // navigational properties
            HasRequired(x => x.EventRequest)
                .WithMany(x => x.Negotiations)
                .HasForeignKey(x => x.EventRequestId);
        }
    }
}
