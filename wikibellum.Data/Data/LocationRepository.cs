﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Data
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(WikiContext context) : base(context)
        {
        }
    }
}
