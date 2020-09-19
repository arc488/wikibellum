using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Data.Data
{
    public class AssetRepository : Repository<Asset>, IAssetRepository
    {
        public AssetRepository(WikiContext context) : base(context)
        {
        }

        public async virtual Task<EntityState> Create(Asset entity)
        {
            var newEntity = await _entries.AddAsync(entity);
            _context.SaveChanges();
            return newEntity.State;

        }
    }
}
