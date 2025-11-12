using System.ComponentModel.DataAnnotations;

namespace FuelRoute.Core.Models;

public class Car
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Make is required")]
    public string Make { get; set; }

    [Required(ErrorMessage = "Model is required")]
    public string Model { get; set; }

    [Required(ErrorMessage = "Year is required")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Fuel efficiency is required")]
    public double Fuel_efficiency { get; set; }

    [Required(ErrorMessage = "Tank capacity is required")]
    public int Tank_capacity { get; set; }

    public FuelType TypeofFuel { get; set; } = FuelType.Regular;
}