using static Domain.SnackPile;

namespace Domain
{
    public class Slot : Entity
    {
        public virtual int Position { get; protected set; }

        public virtual SnackPile SnackPile { get; set; }

        public virtual SnackMachine SnackMachine { get; protected set; }

        public Slot()
        {
        }

        public Slot(SnackMachine snackMachine, int position)
            : this()
        {
            SnackMachine = snackMachine;
            Position = position;
            SnackPile = Empty;
        }
    }
}