using Domain;
using System.Collections.Generic;
using System.Data.Entity;

namespace Infrastructure.Data.Initializer
{
    public class DDDInPracticeDBInitializer : DropCreateDatabaseAlways<DDDInPracticeContext>
    {
        protected override void Seed(DDDInPracticeContext context)
        {
            var snacks = new List<Snack>();

            snacks.Add(Snack.Chocolate);
            snacks.Add(Snack.Gum);
            snacks.Add(Snack.Soda);

            foreach (var std in snacks)
                context.Snack.Add(std);

            context.SnackMachine.Add(SnackMachine.Default);

            base.Seed(context);
        }
    }
}
