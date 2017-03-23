using Domain.Common;
using System;
using static Domain.SnackMachine.Snack;

namespace Domain.SnackMachine
{
    public class SnackPile : ValueObject<SnackPile>
    {
        public static readonly SnackPile Empty = new SnackPile(None, 0, 0m);

        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Snack Snack { get; private set; }

        private SnackPile()
        {
        }

        public SnackPile(Snack snack, int quantity, decimal price)
            : this()
        {
            if (quantity < 0)
                throw new InvalidOperationException();
            if (price < 0)
                throw new InvalidOperationException();
            //Make sure always price is more than 1 cent.
            if (price % 0.01m > 0)
                throw new InvalidOperationException();
            Snack = snack;
            Quantity = quantity;
            Price = price;
        }

        public SnackPile SubstractOne()
        {
            return new SnackPile(Snack, Quantity - 1, Price);
        }

        protected override bool EqualsCore(SnackPile other)
        {
            return Snack == other.Snack
                && Quantity == other.Quantity
                && Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Snack.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }
    }
}