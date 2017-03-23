using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using static Domain.SharedKernel.Money;

namespace Infrastructure.Data.Test
{
    [TestClass]
    public class SessionFactoryTest
    {
        [TestMethod]
        public void Test()
        {
            SessionFactory.Init(ConfigurationManager.ConnectionStrings["DDDInPractice"].ConnectionString);

            var repository = new SnackMachineRepository();
            var snackMachine = repository.GetById(1);
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);
            snackMachine.BuySnack(1);
            repository.Save(snackMachine);
        }
    }
}
