using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.TableMapping
{
    public class SlotMap : EntityTypeConfiguration<Slot>
    {
        public SlotMap()
        {
            HasKey(key => key.Id);
            Property(prop => prop.Position);

            HasRequired(item => item.SnackMachine);
            //HasRequired(item => item.SnackPile.Snack);
        }
    }
}