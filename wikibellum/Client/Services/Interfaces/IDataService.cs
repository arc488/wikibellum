﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace wikibellum.Client.Services
{
    public interface IDataService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<HttpResponseMessage> Update(int id, TEntity entity);
        Task<TEntity> Add(TEntity entity);
        Task Delete(int entityId);

    }
}