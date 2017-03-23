using Domain.Atms;
using Domain.Repository;
using Domain.SharedKernel;
using Infrastructure.Data;
using System.Windows.Forms;
using System;

namespace UI
{
    public partial class AtmForm : Form
    {
        private readonly Atm _atm;
        private readonly IAtmRepository _atmRepository;
        private readonly IPaymentGateway _paymentGateway;

        public AtmForm()
        {
            InitializeComponent();
            _atmRepository = new AtmRepository();
            _paymentGateway = new PaymentGateway();
            _atm = _atmRepository.GetById(1);
            NotifyClient(string.Empty);
        }

        protected Money MoneyInside => _atm.MoneyInside;
        protected string MoneyInTransaction => _atm.MoneyCharged.ToString("C2");

        private void NotifyClient(string message)
        {
            CentLabel.Text = MoneyInside.OneCentCount.ToString();
            TenCentLabel.Text = MoneyInside.TenCentCount.ToString();
            QuarterLabel.Text = MoneyInside.QuarterCount.ToString();
            DollarLabel.Text = MoneyInside.OneDollarCount.ToString();
            FiveDollarLabel.Text = MoneyInside.FiveDollarCount.ToString();
            TwentyDollarLabel.Text = MoneyInside.TwentyDollarCount.ToString();
            MoneyInsideLabel.Text = $"Money inside: {MoneyInside}";
            MoneyCharged.Text = $"Money charged: {MoneyInTransaction}";
            if(!string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TakeMoneyBtn_Click(object sender, System.EventArgs e)
        {
            decimal moneyRequested = 0;
            if (decimal.TryParse(MoneyRequested.Text, out moneyRequested))
            {
                TakeMoney(moneyRequested);
            }
        }

        private void TakeMoney(decimal amount)
        {
            var error = _atm.CanTake(amount);
            if (error != string.Empty)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var amountWithComission = _atm.CalculateWithComission(amount);
            _paymentGateway.ChargePayment(amountWithComission);
            _atm.TakeMoney(amount);
            _atmRepository.Save(_atm);
            NotifyClient($"You have taken {amount.ToString("C2")}");
        }
    }
}
