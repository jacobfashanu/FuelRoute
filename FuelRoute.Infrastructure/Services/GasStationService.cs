using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FuelRoute.Core.Interfaces;
using FuelRoute.Core.Models;

namespace FuelRoute.Infrastructure.Services
{
    public class GasStationService : IGasStationService
    // 2 major jobs this class performs: 1) Convert address to number coordinates 2) Pick the best Gas Station
    {
        // Dependency Injection(Injects the repo that loads the gas station data from the JSON)
        private readonly IGasStationRepository _repo;

        public GasStationService(IGasStationRepository repo)
        {
            _repo = repo;
        }

       
        // Main method: choose gas station based on distance and price
       
        public Task<RouteResult?> GetBestStationAsync(RouteRequest req)
        {
            var stations = _repo.GetAll(); // Loads all station data

            //best variable first calculates the distance between each gas station and the start and end location
            //then it given the distances, it computes a score for each station. The lower the better
            //Then the best station is selected
            var best = stations
                .Select(s => new
                {
                    Station = s,
                    DistStart = Distance(req.StartLat, req.StartLng, s.Lat, s.Lng),
                    DistEnd = Distance(s.Lat, s.Lng, req.EndLat, req.EndLng)
                })
                .Select(x => new
                {
                    x.Station,
                    x.DistStart,
                    x.DistEnd,
                    // Score formula: price + weighted detour distance
                    Score = x.Station.Price + (x.DistStart + x.DistEnd) * 0.05
                })
                .OrderBy(x => x.Score)
                .FirstOrDefault();

            if (best == null)
                return Task.FromResult<RouteResult?>(null);

            // This builds the return object that will be passed to the UI and displayed
            return Task.FromResult<RouteResult?>(new RouteResult
            {
                Station = best.Station,
                DistanceKmFromStart = best.DistStart,
                DistanceKmToEnd = best.DistEnd,
                MapsUrl =
                    $"https://www.google.com/maps/dir/?api=1" +
                    $"&origin={req.StartLat},{req.StartLng}" +
                    $"&destination={best.Station.Lat},{best.Station.Lng}" +
                    $"&waypoints={best.Station.Lat},{best.Station.Lng}"
            });
        }

        // This method converts the addresses into Latitude/Longitudinal coordinates
        // It uses the Nominatim API, apart of OpenStreetMap API
        public async Task<(double lat, double lng)?> GeocodeAsync(string address)
        {
            //Creates the client(user-agent) that makes the API call
            using var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("FuelRouteApp/1.0");

            // Clean Ontario-safe geocoding URL
            string url =
                $"https://nominatim.openstreetmap.org/search?" +
                $"q={Uri.EscapeDataString(address)}" +
                $"&format=json" +
                $"&addressdetails=1" +
                $"&limit=5" +           // get up to 5 options
                $"&countrycodes=ca";     // only Canada

            var json = await client.GetStringAsync(url); // send request

            var results = JsonSerializer.Deserialize<List<NominatimResult>>(json); //deserialize the results

            if (results == null || results.Count == 0)
                return null;

            // Filter: Only Ontario + Only Canada
            var best = results.FirstOrDefault(r =>
                r.address != null &&
                r.address.country?.ToLower().Contains("canada") == true &&
                r.address.state?.ToLower().Contains("ontario") == true
            );

            if (best == null || best.lat == null || best.lon == null)
                return null;

            return (double.Parse(best.lat), double.Parse(best.lon));
        }

       
        // Helper classes to read Nominatim JSON
    
        private class NominatimResult
        {
            public string? lat { get; set; }
            public string? lon { get; set; }
            public NominatimAddress? address { get; set; }
        }

        private class NominatimAddress
        {
            public string? country { get; set; }
            public string? state { get; set; }
            public string? city { get; set; }
            public string? town { get; set; }
            public string? village { get; set; }
        }

        
        // Distance formula (Haversine)
    
        private static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Earth radius in km
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;
            lat1 *= Math.PI / 180;
            lat2 *= Math.PI / 180;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }
    }
}
