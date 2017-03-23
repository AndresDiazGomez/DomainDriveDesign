using System;
using Domain.Repository;

namespace Infrastructure.Data
{
    public class PaymentGateway : IPaymentGateway
    {
        public void ChargePayment(decimal amount)
        {
            //Consume gateway service.

        }
    }
}
