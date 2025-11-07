namespace FuelRoute.Core.Entities
{
    public class GasStation
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Brand { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; } = "";
    }
}