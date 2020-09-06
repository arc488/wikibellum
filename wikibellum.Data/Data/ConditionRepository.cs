using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Data.Data
{
    public class ConditionRepository : Repository<Condition>, IConditionRepository
    {
        public ConditionRepository(WikiContext context) : base(context)
        {
        }
    }
}
