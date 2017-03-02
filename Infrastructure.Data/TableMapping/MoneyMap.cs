using Domain;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.TableMapping
{
    public class MoneyMap : ComplexTypeConfiguration<Money>
    {
        public MoneyMap()
        {
            Ignore(prop => prop.Amount);
            Property(prop => prop.OneCentCount).HasColumnName("OneCentCount");
            Property(prop => prop.TenCentCount).HasColumnName("TenCentCount");
            Property(prop => prop.QuarterCount).HasColumnName("QuarterCount");
            Property(prop => prop.OneDollarCount).HasColumnName("OneDollarCount");
            Property(prop => prop.FiveDollarCount).HasColumnName("FiveDollarCount");
            Property(prop => prop.TwentyDollarCount).HasColumnName("TwentyDollarCount");
        }
    }
}