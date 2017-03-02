using Domain;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
