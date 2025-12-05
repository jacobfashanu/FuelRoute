namespace FuelRoute.Core.Models
{
    public class RouteResult
    {
        public GasStation Station { get; set; }

        public string MapsUrl { get; set; }

        public double DistanceKmFromStart { get; set; }

        // NEW FIELD NEEDED BY THE SERVICE
        public double DistanceKmToEnd { get; set; }
    }
}
