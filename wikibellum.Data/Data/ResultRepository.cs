using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities;

namespace wikibellum.Data.Data
{
    public class ResultRepository : Repository<Result>, IResultRepository
    {
        public ResultRepository(WikiContext context) : base(context)
        {
          
        }
    }
}
