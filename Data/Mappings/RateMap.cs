
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class RateMap : EntityTypeConfiguration<Rate>
    {
        public RateMap()
        {
            // Table 
            ToTable("Rate", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Details)
                .IsOptional();

            Property(c => c.Fee)
                .IsRequired();

            Property(c => c.Period)
                .IsRequired();

            Property(c => c.Status)
                .IsRequired();

            // navigational properties
            HasRequired(x => x.Performer)
                .WithMany(x => x.Rates)
                .HasForeignKey(x => x.PerfomerId);

        }
    }
}
