using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class SnackMachine : AggregateRoot
    {
        public static readonly SnackMachine Default = new SnackMachine()
        {
            Id = new Guid("85a5bbe6-35dc-4806-b7f1-0d1e3cc8a095"),
            MoneyInside = new Money(2, 3, 3, 1, 3, 3)
        };

        public Money MoneyInside { get; protected set; }
        public decimal MoneyInTransaction { get; protected set; }
        protected IList<Slot> Slots { get; set; }

        public SnackMachine()
        {
            MoneyInside = Money.None;
            MoneyInTransaction = 0;
            //This because our machine only have 3 slots.
            Slots = new List<Slot>
            {
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3)
            };
        }

        public void InsertMoney(Money money)
        {
            var coinsAndNotes = new[] { Money.Cent, Money.TenCent, Money.Quarter, Money.Dollar, Money.FiveDollar, Money.TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();
            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public void ReturnMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0;
        }

        public void BuySnack(int position)
        {
            Slot slot = GetSlot(position);
            if (slot.SnackPile.Price > MoneyInTransaction)
            {
                throw new InvalidOperationException();
            }
            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            if (change.Amount < MoneyInTransaction - slot.SnackPile.Price)
            {
                throw new InvalidOperationException();
            }
            slot.SnackPile = slot.SnackPile.SubstractOne();
            MoneyInside -= change;
            MoneyInTransaction = 0;
        }

        public void LoadSnack(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public SnackPile GetSnackPile(int position)
        {
            return GetSlot(position).SnackPile;
        }

        public virtual IReadOnlyCollection<SnackPile> GetAllSnackPiles()
        {
            return Slots
                .OrderBy(item => item.Position)
                .Select(item => item.SnackPile)
                .ToList();
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}