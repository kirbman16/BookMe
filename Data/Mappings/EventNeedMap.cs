
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class EventNeedMap : EntityTypeConfiguration<EventNeed>
    {
        public EventNeedMap()
        {
            // Table 
            ToTable("EventNeed", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Quantity)
                .IsRequired();

            // navigational properties
            HasRequired(x => x.Event)
                .WithMany(x => x.Needs)
                .HasForeignKey(x => x.EventId);

            HasRequired(x => x.Category)
                .WithMany(x => x.Needed)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
