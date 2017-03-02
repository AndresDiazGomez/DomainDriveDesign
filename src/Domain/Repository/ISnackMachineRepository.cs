using System;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface ISnackMachineRepository : IRepository<SnackMachine>
    {
        IReadOnlyList<SnackMachine> GetAllWithSnack(Snack snack);
        IReadOnlyList<SnackMachine> GetAllWithMoneyInside(Money money);
    }
}