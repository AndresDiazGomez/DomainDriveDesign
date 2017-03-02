using System;

namespace Domain
{
    public class Snack : AggregateRoot
    {
        public static readonly Snack None = new Snack(Guid.Empty, "None");
        public static readonly Snack Chocolate = new Snack(new Guid("07fc9144-bf8c-4874-bba5-fb7afc26246b"), "Chocolate");
        public static readonly Snack Gum = new Snack(new Guid("a4aa4853-f4f6-4407-875b-78525939c5cc"), "Gum");
        public static readonly Snack Soda = new Snack(new Guid("4a679df4-5fbc-416e-aaf7-4d398111d097"), "Soda");

        public string Name { get; protected set; }

        private Snack()
        {
        }

        private Snack(Guid id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}