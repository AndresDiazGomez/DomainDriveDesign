using Domain;
using Domain.SnackMachine;
using System;

namespace UI.Model
{
    public class SnackPileModel
    {
        private readonly SnackPile _snackPile;

        public SnackPileModel(SnackPile snackPile)
        {
            _snackPile = snackPile;
        }

        public string Amount => $"{_snackPile.Quantity} left.";
        public string ImageSource => $@"{AppDomain.CurrentDomain.BaseDirectory}\Images\{_snackPile.Snack.Name}.jpg";
        public int ImageWidth => GetImageWidth(_snackPile.Snack);
        public string Name => _snackPile.Snack.Name;
        public string Price => _snackPile.Price.ToString("C2");

        private int GetImageWidth(Snack snack)
        {
            if (snack == Snack.Chocolate)
                return 120;

            if (snack == Snack.Soda)
                return 70;

            if (snack == Snack.Gum)
                return 70;

            throw new ArgumentNullException(nameof(snack));
        }
    }
}