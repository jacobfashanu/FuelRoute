namespace FuelRoute.Core.Models
{
    public class GasStation // this model holds data that is stored in the gas station.json file.
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Gas Station";
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Price { get; set; }
    }
}
