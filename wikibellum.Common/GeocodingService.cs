using Geocoding;
using Geocoding.Microsoft;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace wikibellum.Common
{
    public class GeocodingService : IGeocodingService
    {
        private readonly string _apiKey;

        public GeocodingService(string apiKey)
        {
            _apiKey = apiKey;

        }

        public Dictionary<string, double> GetCoordinates(string location)
        {
            string address = location;

            IGeocoder geocoder = new BingMapsGeocoder(_apiKey);
            var result = new Dictionary<string, double>();
            try
            {
                IEnumerable<Address> response = geocoder.Geocode(location);

                if (response != null)
                {
                    result.Add("lat", response.First().Coordinates.Latitude);
                    result.Add("long", response.First().Coordinates.Longitude);

                    Debug.WriteLine("Location: " + location);
                    Debug.WriteLine("Lat: " + result["lat"]);
                    Debug.WriteLine("Long: " + result["long"]);
                };
            } catch (Exception e)
            {
                Debug.WriteLine("Exception was thrown while processing location: " + location);
                Debug.WriteLine(e.Message);
                result.Add("lat", 0);
                result.Add("long", 0);
            }


            return result;
        }
    }
}
