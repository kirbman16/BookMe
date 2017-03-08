
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class OrganizationMap : EntityTypeConfiguration<Organization>
    {
        public OrganizationMap()
        {
            // Table 
            ToTable("Organization", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Name)
                .IsRequired();

            Property(c => c.ContactName)
                .IsRequired();

            Property(c => c.ContactNumber)
                .IsOptional();

            Property(c => c.ContactEmail)
                .IsOptional();

            Property(c => c.HideContactInfo)
                .IsRequired();

            Property(c => c.Details)
                .IsOptional();

            Property(c => c.City)
                .IsOptional();

            Property(c => c.ZipCode)
                .IsOptional();

            Property(c => c.State)
                .IsOptional();

            // navigational properties
            HasRequired(x => x.Account)
                .WithMany(x => x.Organizations)
                .HasForeignKey(x => x.AccountId);

            HasMany(x => x.Events)
                .WithRequired(x => x.Organization)
                .HasForeignKey(x => x.OrganizationId);
        }
    }
}
