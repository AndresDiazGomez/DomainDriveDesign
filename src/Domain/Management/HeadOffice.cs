using Domain.Common;
using Domain.SharedKernel;
using static Domain.SharedKernel.Money;

namespace Domain.Management
{
    public class HeadOffice : AggregateRoot
    {
        public virtual decimal Balance { get; protected set; }
        public virtual Money Cash { get; protected set; }

        public HeadOffice()
        {
            Cash = None;
        }

        public virtual void ChangeBalance(decimal delta)
        {
            Balance += delta;
        }
    }
}
