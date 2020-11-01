using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models;

namespace wikibellum.Data.Data
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(WikiContext context) : base(context)
        {
            
        }
    }
}
