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

        public async virtual Task<EntityState> Create(TEntity entity)
        {
            var newEntity = await _entries.AddAsync(entity);
            _context.SaveChanges();
            return newEntity.State;

        }

        public virtual EntityState Delete(TEntity entity)
        {
            var state = _entries.Remove(entity).State;
            _context.SaveChanges();
            return state;
        }
         
        public async virtual Task<TEntity> Get(int id)
        {
            var entity = await _entries.FindAsync(id);
            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            var entities = await _entries.ToListAsync();
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
