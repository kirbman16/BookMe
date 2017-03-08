
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            // Table 
            ToTable("Event", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Name)
                .IsRequired();

            Property(c => c.Address)
                .IsOptional();

            Property(c => c.City)
                .IsOptional();

            Property(c => c.Zip)
                .IsOptional();

            Property(c => c.State)
                .IsOptional();

            Property(c => c.StartDate)
                .IsRequired()
                .HasColumnType("date");

            Property(c => c.EndDate)
                .IsRequired()
                .HasColumnType("date");

            Property(c => c.Budget)
                .IsOptional();

            Property(c => c.Status)
                .IsRequired();

            Property(c => c.CancellationDate)
                .IsOptional()
                .HasColumnType("date");


            // navigational properties
            HasRequired(x => x.Organization)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.OrganizationId);

            HasMany(x => x.Requests)
                .WithRequired(x => x.Event)
                .HasForeignKey(x => x.EventId);

            HasMany(x => x.Needs)
                .WithRequired(x => x.Event)
                .HasForeignKey(x => x.EventId);
        }
    }
}
