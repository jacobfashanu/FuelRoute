namespace FuelRoute.Core.Models;

public class Car
{
    public int UserId { get; set; }

    public string Email { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }

    public double Fuel_efficiency { get; set; }

    public int Tank_capacity { get; set; }

    public FuelType TypeofFuel { get; set; } = FuelType.Regular;
}