using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Create, read, update and delete
        Task<EntityState> Create(TEntity entity);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<EntityState> Update(TEntity entity);
        EntityState Delete(TEntity entity);
    }
}
