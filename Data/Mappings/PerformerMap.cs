
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class PerformerMap : EntityTypeConfiguration<Performer>
    {
        public PerformerMap()
        {
            // Table 
            ToTable("Performer", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.FirstName)
                .IsOptional();

            Property(c => c.LastName)
                .IsOptional();

            Property(c => c.StageName)
                .IsRequired();

            Property(c => c.PhoneNumber)
                .IsOptional();

            Property(c => c.Email)
                .IsOptional();

            Property(c => c.HidePhoneNumber)
                .IsRequired();

            Property(c => c.HideEmail)
                .IsRequired();

            // navigational properties
            HasRequired(x => x.Account)
                .WithMany(x => x.Performers)
                .HasForeignKey(x => x.AccountId);

            HasMany(x => x.Rates)
                .WithRequired(x => x.Performer)
                .HasForeignKey(x => x.PerfomerId);

            HasMany(x => x.Requests)
                .WithRequired(x => x.Performer)
                .HasForeignKey(x => x.PerformerId);
        }
    }
}
