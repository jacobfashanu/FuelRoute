using System.Threading.Tasks;
using FuelRoute.Core.Models;

namespace FuelRoute.Core.Interfaces
{
    public interface IGasStationService
    {
        Task<RouteResult?> GetBestStationAsync(RouteRequest request);

        // NEW: for address support
        Task<(double lat, double lng)?> GeocodeAsync(string address);
    }
}
