using System;
using System.Collections.Generic;
using System.Text;

namespace wikibellum.Common
{
    public interface IGeocodingService
    {
        Dictionary<string, double> GetCoordinates(string location);
    }
}
