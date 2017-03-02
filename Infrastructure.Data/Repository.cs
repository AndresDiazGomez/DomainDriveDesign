using Domain;
using Domain.Repository;
using System;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Data
{
    public abstract class Repository<T> : IRepository<T>
        where T : AggregateRoot
    {
        DDDInPracticeContext _context;
        DbSet<T> _entity;

        public Repository()
        {
            _context = new DDDInPracticeContext();
            _entity = _context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _entity.FirstOrDefault(entity => entity.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}