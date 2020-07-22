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
        EntityState Create(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        EntityState Update(TEntity entity);
        EntityState Delete(TEntity entity);
    }
}
