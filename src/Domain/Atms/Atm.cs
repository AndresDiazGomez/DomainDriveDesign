using Domain.Common;
using Domain.SharedKernel;
using System;
using static Domain.SharedKernel.Money;

namespace Domain.Atms
{
    public class Atm : AggregateRoot
    {
        private const decimal ComissionRate = 0.01m;

        public virtual Money MoneyInside { get; protected set; }
        public virtual decimal MoneyCharged { get; protected set; }

        public Atm()
        {
            MoneyInside = None;
        }

        public virtual string CanTake(decimal amount)
        {
            if(amount <= 0)
            {
                return "Invalid amount.";
            }
            if (MoneyInside.Amount < amount)
            {
                return "Not enough money.";
            }
            if (!MoneyInside.CanAllocate(amount))
            {
                return "Not enough change.";
            }
            return string.Empty;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

        public virtual void TakeMoney(decimal amount)
        {
            if(CanTake(amount) != string.Empty)
            {
                throw new InvalidOperationException();
            }

            Money output = MoneyInside.Allocate(amount);
            MoneyInside -= output;

            decimal amountWithComission = CalculateWithComission(amount);
            MoneyCharged += amountWithComission;

            AddDomainEvent(new BalanceChangedEvent(amountWithComission));
        }

        public virtual decimal CalculateWithComission(decimal amount)
        {
            decimal comission = amount * ComissionRate;
            decimal lessThanCent = comission % 0.01m;
            if(lessThanCent > 0)
            {
                comission = comission - lessThanCent + 0.01m;
            }
            return amount + comission;
        }
    }
}
