
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Table 
            ToTable("Category", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Name)
                .IsRequired();
            
            // navigational properties
            HasMany(x => x.Performers)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            HasMany(x => x.Needed)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
