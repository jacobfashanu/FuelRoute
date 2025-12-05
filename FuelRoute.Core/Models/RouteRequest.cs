namespace FuelRoute.Core.Models
{
    public class RouteRequest
    {
        // Starting point
        public double StartLat { get; set; }
        public double StartLng { get; set; }

        public double EndLat { get; set; }
        public double EndLng { get; set; }
    }
}
