namespace FuelRoute.Core.Models
{
    public class RouteResult // this model represents the output returned to the frontend
    {
        public GasStation Station { get; set; }

        public string MapsUrl { get; set; }

        public double DistanceKmFromStart { get; set; }

        
        public double DistanceKmToEnd { get; set; }
    }
}
