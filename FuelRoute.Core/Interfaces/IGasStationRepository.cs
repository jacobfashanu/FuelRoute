using System.Collections.Generic;
using FuelRoute.Core.Models;

namespace FuelRoute.Core.Interfaces 

{
    public interface IGasStationRepository // This defines how gas station data is retrieved
    //Simply requires that the implemented repository have a function that retrieves all of the gas stations stored in the db.
    // In our case the, database only stores gas station data for Ontario alone.
    {
        IReadOnlyList<GasStation> GetAll();
    }
}
