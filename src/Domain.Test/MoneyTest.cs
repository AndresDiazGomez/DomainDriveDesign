using Domain.SharedKernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Test
{
    [TestClass]
    public class MoneyTest
    {
        [TestMethod]
        public void Sum_of_two_moneys_produces_correct_result()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var result = money1 + money2;

            Assert.AreEqual(result.OneCentCount, 2);
            Assert.AreEqual(result.TenCentCount, 4);
            Assert.AreEqual(result.QuarterCount, 6);
            Assert.AreEqual(result.OneDollarCount, 8);
            Assert.AreEqual(result.FiveDollarCount, 10);
            Assert.AreEqual(result.TwentyDollarCount, 12);
        }

        [TestMethod]
        public void Two_money_instances_equal_if_contain_the_same_money_amount()
        {
            var money1 = new Money(1, 2, 3, 4, 5, 6);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            Assert.AreEqual(money1, money2);
            Assert.AreEqual(money1.GetHashCode(), money2.GetHashCode());
        }

        [TestMethod]
        public void Two_money_instances_not_equal_if_contain_different_money_amount()
        {
            var dollar = new Money(0, 0, 0, 1, 0, 0);
            var hundredCents = new Money(100, 0, 0, 0, 0, 0);

            Assert.AreNotEqual(dollar, hundredCents);
            Assert.AreNotEqual(dollar.GetHashCode(), hundredCents.GetHashCode());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_create_money_with_negative_value()
        {
            var money = new Money(-1, 0, 0, 0, 0, 0);
            var money1 = new Money(0, -2, 0, 0, 0, 0);
            var money2 = new Money(0, 0, -3, 0, 0, 0);
            var money3 = new Money(0, 0, 0, -4, 0, 0);
            var money4 = new Money(0, 0, 0, 0, -5, 0);
            var money5 = new Money(0, 0, 0, 0, 0, -6);
        }

        [TestMethod]
        public void Amount_is_calculate_correctly()
        {
            var money = new Money(0, 0, 0, 0, 0, 0);
            Assert.AreEqual(money.Amount, 0);
            var money1 = new Money(1, 0, 0, 0, 0, 0);
            Assert.AreEqual(money1.Amount, 0.01m);
            var money2 = new Money(1, 2, 0, 0, 0, 0);
            Assert.AreEqual(money2.Amount, 0.21m);
            var money3 = new Money(1, 2, 3, 0, 0, 0);
            Assert.AreEqual(money3.Amount, 0.96m);
            var money4 = new Money(1, 2, 3, 4, 0, 0);
            Assert.AreEqual(money4.Amount, 4.96m);
            var money5 = new Money(1, 2, 3, 4, 5, 0);
            Assert.AreEqual(money5.Amount, 29.96m);
            var money6 = new Money(1, 2, 3, 4, 5, 6);
            Assert.AreEqual(money6.Amount, 149.96m);
            var money7 = new Money(11, 0, 0, 0, 0, 0);
            Assert.AreEqual(money7.Amount, 0.11m);
            var money8 = new Money(110, 0, 0, 0, 100, 0);
            Assert.AreEqual(money8.Amount, 501.1m);
        }

        [TestMethod]
        public void Substraction_of_two_moneys_produces_correct_result()
        {
            var money1 = new Money(10, 10, 10, 10, 10, 10);
            var money2 = new Money(1, 2, 3, 4, 5, 6);

            var result = money1 - money2;

            Assert.AreEqual(result.OneCentCount, 9);
            Assert.AreEqual(result.TenCentCount, 8);
            Assert.AreEqual(result.QuarterCount, 7);
            Assert.AreEqual(result.OneDollarCount, 6);
            Assert.AreEqual(result.FiveDollarCount, 5);
            Assert.AreEqual(result.TwentyDollarCount, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_substract_more_than_exists()
        {
            var money1 = new Money(0, 1, 0, 0, 0, 0);
            var money2 = new Money(1, 0, 0, 0, 0, 0);

            var result = money1 - money2;
        }

        [TestMethod]
        public void ToString_should_return_amount_of_money()
        {
            var money1 = new Money(1, 0, 0, 0, 0, 0);
            Assert.AreEqual(money1.ToString(), "¢1");

            var money2 = new Money(0, 0, 0, 1, 0, 0);
            Assert.AreEqual(money2.ToString(), "$1,00");

            var money3 = new Money(1, 0, 0, 1, 0, 0);
            Assert.AreEqual(money3.ToString(), "$1,01");

            var money4 = new Money(0, 0, 2, 1, 0, 0);
            Assert.AreEqual(money4.ToString(), "$1,50");
        }
    }
}