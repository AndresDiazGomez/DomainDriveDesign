using System;

namespace Domain.Repository
{
    public interface IRepository<T> where T : AggregateRoot
    {
        T GetById(Guid id);

        void Save();
    }
}