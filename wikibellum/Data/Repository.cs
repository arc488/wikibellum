using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Models;

namespace wikibellum.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly WikiContext _context;
        private readonly DbSet<TEntity> _entries;

        public Repository(WikiContext context)
        {
            _context = context;
            _entries = _context.Set<TEntity>();
        }

        public EntityState Create(TEntity entity)
        {
            var state = _entries.Add(entity).State;
            _context.SaveChanges();
            return state;

        }

        public EntityState Delete(TEntity entity)
        {
            var state = _entries.Remove(entity).State;
            _context.SaveChanges();
            return state;
        }

        public TEntity Get(int id)
        {
            return _entries.Find(id);
        }

        public EntityState Update(TEntity entity)
        {
            var state = _entries.Update(entity).State;
            _context.SaveChanges();
            return state;
        }
    }
}
