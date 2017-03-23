namespace Domain.Repository
{
    public interface IPaymentGateway
    {
        void ChargePayment(decimal amount);
    }
}
