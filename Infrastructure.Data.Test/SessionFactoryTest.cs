using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using NHibernate;
using Domain;

namespace Infrastructure.Data.Test
{
    [TestClass]
    public class SessionFactoryTest
    {
        [TestMethod]
        public void InitTest()
        {
            SessionFactory.Init(ConfigurationManager.ConnectionStrings["DDDInPractice"].ConnectionString);

            using (ISession session = SessionFactory.OpenSession())
            {
                long id = 1;
                var snackMachine = session.Get<SnackMachine>(id);
            }
        }
    }
}
