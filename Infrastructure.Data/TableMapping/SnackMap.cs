using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.TableMapping
{
    public class SnackMap : EntityTypeConfiguration<Snack>
    {
        public SnackMap()
        {
            HasKey(key => key.Id);
            Property(prop => prop.Name);
        }
    }
}