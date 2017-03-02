using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.TableMapping
{
    public class SnackMachineMap : EntityTypeConfiguration<SnackMachine>
    {
        public SnackMachineMap()
        {
            HasKey(key => key.Id);
            Ignore(prop => prop.MoneyInTransaction);
        }
    }
}