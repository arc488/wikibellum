using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.App.Services
{
    public interface IDataService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
