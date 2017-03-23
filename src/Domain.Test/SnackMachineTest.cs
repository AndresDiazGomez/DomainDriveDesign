using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.SnackMachine;
using static Domain.SharedKernel.Money;
using static Domain.SnackMachine.Snack;

namespace Domain.Test
{
    [TestClass]
    public class SnackMachineTest
    {
        [TestMethod]
        public void Return_money_empties_money_in_transaction()
        {
            var snackMachine = new SnackMachine.SnackMachine();

            snackMachine.InsertMoney(Dollar);
            snackMachine.ReturnMoney();

            Assert.AreEqual(snackMachine.MoneyInTransaction, 0);
        }

        [TestMethod]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new SnackMachine.SnackMachine();

            snackMachine.InsertMoney(Cent);
            snackMachine.InsertMoney(Dollar);

            Assert.AreEqual(snackMachine.MoneyInTransaction, 1.01m);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_insert_more_than_one_coin_or_note_at_a_time()
        {
            var snackMachine = new SnackMachine.SnackMachine();
            var twoCents = Cent + Cent;

            snackMachine.InsertMoney(twoCents);
        }

        [TestMethod]
        public void BuySnack_trades_inserted_money_for_a_snack()
        {
            var snackMachine = new SnackMachine.SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(Chocolate, 10, 1m));
            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack(1);

            Assert.AreEqual(snackMachine.MoneyInTransaction, 0m);
            Assert.AreEqual(snackMachine.MoneyInside.Amount, 1m);
            Assert.AreEqual(snackMachine.GetSnackPile(1).Quantity, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_make_purchase_when_there_is_no_snacks()
        {
            var snackMachine = new SnackMachine.SnackMachine();
            snackMachine.BuySnack(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_make_purchase_if_not_enough_money_inserted()
        {
            var snackMachine = new SnackMachine.SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(Chocolate, 1, 2m));
            snackMachine.InsertMoney(Dollar);
            snackMachine.BuySnack(1);
        }

        [TestMethod]
        public void Snack_machine_returns_money_with_highest_denomination_first()
        {
            var snackMachine = new SnackMachine.SnackMachine();
            snackMachine.LoadMoney(Dollar);
            snackMachine.InsertMoney(Quarter);
            snackMachine.InsertMoney(Quarter);
            snackMachine.InsertMoney(Quarter);
            snackMachine.InsertMoney(Quarter);

            snackMachine.ReturnMoney();

            Assert.AreEqual(snackMachine.MoneyInside.QuarterCount, 4);
            Assert.AreEqual(snackMachine.MoneyInside.FiveDollarCount, 0);
        }

        [TestMethod]
        public void After_purchase_change_is_returned()
        {
            var snackMachine = new SnackMachine.SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(Chocolate, 1, 0.5m));
            snackMachine.LoadMoney(TenCent * 10);

            snackMachine.InsertMoney(Dollar);
            snackMachine.BuySnack(1);

            Assert.AreEqual(snackMachine.MoneyInside.Amount, 1.5m);
            Assert.AreEqual(snackMachine.MoneyInTransaction, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_buy_a_snack_if_not_enough_change()
        {
            var snackMachine = new SnackMachine.SnackMachine();
            snackMachine.LoadSnack(1, new SnackPile(Chocolate, 1, 0.5m));
            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack(1);

            Assert.AreEqual(snackMachine.MoneyInside.Amount, 1.5m);
            Assert.AreEqual(snackMachine.MoneyInTransaction, 0);
        }
    }
}