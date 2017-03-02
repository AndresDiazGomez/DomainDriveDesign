using Domain;
using Infrastructure.Data.Initializer;
using Infrastructure.Data.TableMapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure.Data
{
    public class DDDInPracticeContext : DbContext
    {
        public DDDInPracticeContext()
        {
            //Database.SetInitializer(new DDDInPracticeDBInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<SnackMachine> SnackMachine { get; set; }
        public DbSet<Slot> Slot { get; set; }
        public DbSet<Snack> Snack { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new MoneyMap());
            modelBuilder.Configurations.Add(new SnackPileMap());
            modelBuilder.Configurations.Add(new SnackMachineMap());
            modelBuilder.Configurations.Add(new SlotMap());
            modelBuilder.Configurations.Add(new SnackMap());
        }
    }
}