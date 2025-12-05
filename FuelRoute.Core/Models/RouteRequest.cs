namespace FuelRoute.Core.Models
{
    public class RouteRequest // This model holds the coordinates of the start and end location
    // The serbice uses these to compute a score that represents which gas station is the best option
    {
        
        public double StartLat { get; set; }
        public double StartLng { get; set; }

        public double EndLat { get; set; }
        public double EndLng { get; set; }
    }
}
