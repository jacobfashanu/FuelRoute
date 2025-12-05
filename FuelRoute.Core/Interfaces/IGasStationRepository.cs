using System.Collections.Generic;
using FuelRoute.Core.Models;

namespace FuelRoute.Core.Interfaces

{
    public interface IGasStationRepository
    {
        IReadOnlyList<GasStation> GetAll();
    }
}
