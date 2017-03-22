using Domain;
using Domain.Repository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Model;
using System.Linq;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly SnackMachine _snackMachine;
        private readonly ISnackMachineRepository _snackMachineRepository;

        public Form1()
        {
            InitializeComponent();
            _snackMachineRepository = new SnackMachineRepository();
            _snackMachine = _snackMachineRepository.GetById(1);
            NotifyClient(string.Empty);
            SetSnackPiles(_snackMachine
                .GetAllSnackPiles()
                .Select(item => new SnackPileModel(item))
                .ToList());
        }

        private void SetSnackPiles(ICollection<SnackPileModel> piles)
        {
            foreach (var pile in piles)
            {
                var picture = Controls.Find($"picture_{pile.Name}", true).FirstOrDefault() as PictureBox;
                if (picture != null)
                {
                    picture.ImageLocation = pile.ImageSource;
                    picture.Width = pile.ImageWidth;
                }
            }
        }

        protected Money MoneyInside => _snackMachine.MoneyInside;
        protected string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();

        private void BuySnack(int position)
        {
            _snackMachine.BuySnack(position);
            _snackMachineRepository.Save(_snackMachine);
            NotifyClient("You have bought a snack");
        }

        private void BuySnackButtonOne_Click(object sender, EventArgs e)
        {
            BuySnack(1);
        }

        private void BuySnackButtonThree_Click(object sender, EventArgs e)
        {
            BuySnack(3);
        }

        private void BuySnackButtonTwo_Click(object sender, EventArgs e)
        {
            BuySnack(2);
        }

        private void CentButton_Click(object sender, EventArgs e)
        {
            InsertMoney(Money.Cent);
        }

        private void DollarButton_Click(object sender, EventArgs e)
        {
            InsertMoney(Money.Dollar);
        }

        private void FiveDollarButton_Click(object sender, EventArgs e)
        {
            InsertMoney(Money.FiveDollar);
        }

        private void InsertMoney(Money money)
        {
            _snackMachine.InsertMoney(money);
            NotifyClient($"You have inserted: {money}");
        }

        private void NotifyClient(string message)
        {
            CentLabel.Text = MoneyInside.OneCentCount.ToString();
            TenCentLabel.Text = MoneyInside.TenCentCount.ToString();
            QuarterLabel.Text = MoneyInside.QuarterCount.ToString();
            DollarLabel.Text = MoneyInside.OneDollarCount.ToString();
            FiveDollarLabel.Text = MoneyInside.FiveDollarCount.ToString();
            TwentyDollarLabel.Text = MoneyInside.TwentyDollarCount.ToString();
            MoneyInTransactionLabel.Text = $"Money inserted: {MoneyInTransaction}";
            MoneyInsideLabel.Text = $"Money inside: {MoneyInside}";
            MessageLabel.Text = message;
        }

        private void QuarterButton_Click(object sender, EventArgs e)
        {
            InsertMoney(Money.Quarter);
        }

        private void ReturnMoneyButton_Click(object sender, EventArgs e)
        {
            _snackMachine.ReturnMoney();
            NotifyClient("Money was returned");
        }

        private void TenCentButton_Click(object sender, EventArgs e)
        {
            InsertMoney(Money.TenCent);
        }

        private void TwentyDollarButton_Click(object sender, EventArgs e)
        {
            InsertMoney(Money.TwentyDollar);
        }
    }
}