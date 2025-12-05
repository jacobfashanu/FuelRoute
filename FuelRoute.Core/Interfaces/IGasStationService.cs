using System.Threading.Tasks;
using FuelRoute.Core.Models;

namespace FuelRoute.Core.Interfaces
{
    public interface IGasStationService //Defines the contract for the implemented service of finding the correct gas station data.
    {
        Task<RouteResult?> GetBestStationAsync(RouteRequest request);

        
        Task<(double lat, double lng)?> GeocodeAsync(string address);
    }
}
