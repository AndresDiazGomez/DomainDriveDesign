using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Atms;
using static Domain.SharedKernel.Money;

namespace Domain.Test
{
    [TestClass]
    public class AtmTest
    {
        [TestMethod]
        public void Take_money_exchanges_money_with_comission()
        {
            var atm = new Atm();
            atm.LoadMoney(Dollar);

            atm.TakeMoney(Dollar.Amount);

            Assert.AreEqual(atm.MoneyInside.Amount, 0);
            Assert.AreEqual(atm.MoneyCharged, 1.01m);
        }

        [TestMethod]
        public void Comission_is_at_least_one_cent()
        {
            var atm = new Atm();
            atm.LoadMoney(Cent);

            atm.TakeMoney(Cent.Amount);

            Assert.AreEqual(atm.MoneyCharged, 0.02m);
        }

        [TestMethod]
        public void Comission_is_rounded_up_to_next_cent()
        {
            var atm = new Atm();
            var DollarAndCent = Dollar + TenCent;
            atm.LoadMoney(DollarAndCent);

            atm.TakeMoney(DollarAndCent.Amount);

            Assert.AreEqual(atm.MoneyCharged, 1.12m);
        }
    }
}
