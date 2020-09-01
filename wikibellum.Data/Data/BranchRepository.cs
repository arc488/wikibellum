using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Data.Data
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(WikiContext context) : base(context)
        {
        }
    }
}
