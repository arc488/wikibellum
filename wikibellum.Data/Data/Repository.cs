using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly WikiContext _context;
        protected readonly DbSet<TEntity> _entries;

        public Repository(WikiContext context)
        {
            _context = context;
            _entries = _context.Set<TEntity>();
        }

        public virtual EntityState Create(TEntity entity)
        {
            var state = _entries.Add(entity).State;
            _context.SaveChanges();
            return state;

        }

        public virtual EntityState Delete(TEntity entity)
        {
            var state = _entries.Remove(entity).State;
            _context.SaveChanges();
            return state;
        }

        public virtual TEntity Get(int id)
        {
            return _entries.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var entities = _entries.ToList();
            return entities;
        }

        public virtual EntityState Update(TEntity entity)
        {
            var entry = _entries.Update(entity);
            _context.SaveChanges();
            return entry.State;
        }
    }
}
