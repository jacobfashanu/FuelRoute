using FuelRoute.Core.Entities;

namespace FuelRoute.Infrastructure.Repositories
{
    public class GasStationRepository
    {
        private readonly List<GasStation> _stations = new();

        public IEnumerable<GasStation> GetAll() => _stations;

        public void Add(GasStation station)
        {
            _stations.Add(station);
        }
    }
} 