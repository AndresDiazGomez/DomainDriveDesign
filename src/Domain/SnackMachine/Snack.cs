using Domain.Common;

namespace Domain.SnackMachine
{
    public class Snack : AggregateRoot
    {
        public static readonly Snack None = new Snack(0, "None");
        public static readonly Snack Chocolate = new Snack(1, "Chocolate");
        public static readonly Snack Gum = new Snack(2, "Gum");
        public static readonly Snack Soda = new Snack(3, "Soda");

        public virtual string Name { get; protected set; }

        protected Snack()
        {
        }

        private Snack(long id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}