using System;
using Domain.Atms;
using Domain.Common;
using Domain.Repository;

namespace Domain.Management
{
    public class BalanceChangedEventHandler : IHandler<BalanceChangedEvent>
    {
        public void Handle(BalanceChangedEvent domainEvent)
        {
            HeadOffice headOffice = HeadOfficeInstance.Instance;
            headOffice.ChangeBalance(domainEvent.Delta);
            HeadOfficeInstance.Save();
        }
    }
}
