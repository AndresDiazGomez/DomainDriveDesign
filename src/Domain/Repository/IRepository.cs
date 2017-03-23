using Domain.Common;

namespace Domain.Repository
{
    public interface IRepository<T> where T : AggregateRoot
    {
        T GetById(long id);

        void Save(T aggregateRoot);
    }
}