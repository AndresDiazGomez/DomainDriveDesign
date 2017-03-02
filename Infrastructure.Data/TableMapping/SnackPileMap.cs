using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.TableMapping
{
    public class SnackPileMap : ComplexTypeConfiguration<SnackPile>
    {
        public SnackPileMap()
        {
            Property(prop => prop.Price).HasColumnName("Price");
            Property(prop => prop.Quantity).HasColumnName("Quantity");
        }
    }
}