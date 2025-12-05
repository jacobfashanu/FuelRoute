namespace FuelRoute.Web.Models
{
    public class ApiResult
    {
        public Station Station { get; set; }
        public string MapsUrl { get; set; }
        public double DistanceKmFromStart { get; set; }
    }
}
