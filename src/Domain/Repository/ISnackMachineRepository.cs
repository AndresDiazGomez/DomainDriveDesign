using Domain.SharedKernel;
using Domain.SnackMachine;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface ISnackMachineRepository : IRepository<SnackMachine.SnackMachine>
    {
        IReadOnlyList<SnackMachine.SnackMachine> GetAllWithSnack(Snack snack);

        IReadOnlyList<SnackMachine.SnackMachine> GetAllWithMoneyInside(Money money);
    }
}