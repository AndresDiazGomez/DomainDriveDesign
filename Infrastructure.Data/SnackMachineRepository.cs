using Domain.Repository;
using Domain.SharedKernel;
using Domain.SnackMachine;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class SnackMachineRepository : Repository<SnackMachine>, ISnackMachineRepository
    {
        public IReadOnlyList<SnackMachine> GetAllWithMoneyInside(Money money)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SnackMachine> GetAllWithSnack(Snack snack)
        {
            throw new NotImplementedException();
        }
    }
}
