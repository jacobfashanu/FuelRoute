using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FuelRoute.Core.Models;
using FuelRoute.Core.Interfaces;
using Microsoft.Extensions.Hosting;

namespace FuelRoute.Infrastructure.Repositories
{
    public class GasStationRepository : IGasStationRepository // Loads all gas station data from the local JSON file
    {
        private readonly List<GasStation> _stations;

        public GasStationRepository(IHostEnvironment env)
        {
            // Primary path: ../FuelRoute.Infrastructure/Data/gasstations.json
            var path = Path.Combine(env.ContentRootPath, "..", "FuelRoute.Infrastructure", "Data", "gasstations.json");
            path = Path.GetFullPath(path);

            // Fallback path: FuelRoute.API/Data/gasstations.json
            if (!File.Exists(path))
            {
                var fallbackPath = Path.Combine(env.ContentRootPath, "Data", "gasstations.json");
                fallbackPath = Path.GetFullPath(fallbackPath);

                if (File.Exists(fallbackPath))
                    path = fallbackPath;
            }

            var json = File.ReadAllText(path);

            _stations = JsonSerializer.Deserialize<List<GasStation>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<GasStation>();
        }

        public IReadOnlyList<GasStation> GetAll() => _stations;
    }
}
