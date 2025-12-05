using Microsoft.AspNetCore.Mvc;
using FuelRoute.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRoute.Web.Controllers
{
    public class GasStationsController : Controller
    {
        // For now, we'll use dummy data. Later, you'll connect to your API or repository
        
        // GET: GasStations/Results
        public IActionResult Results(string startLocation, string endLocation)
        {
            if (string.IsNullOrEmpty(startLocation) || string.IsNullOrEmpty(endLocation))
            {
                TempData["Error"] = "Please provide both start and end locations.";
                return RedirectToAction("Index", "Home");
            }

            // Pass route info to view
            ViewBag.StartLocation = startLocation;
            ViewBag.EndLocation = endLocation;
            ViewBag.TotalDistance = 45.5; // Dummy data

            // Create dummy gas station data for demo
            var stations = GetDummyGasStations();

            return View(stations);
        }

        // GET: GasStations/Details/5
        public IActionResult Details(int id)
        {
            // Get dummy station data
            var station = GetDummyStationDetails(id);

            if (station == null)
            {
                TempData["Error"] = "Gas station not found.";
                return RedirectToAction("Results");
            }

            return View(station);
        }

        // POST: GasStations/ReportPrice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReportPrice(int stationId, string fuelType, decimal price)
        {
            // For now, just show success message
            TempData["Success"] = "Thank you for reporting the price! Your contribution helps the community.";
            return RedirectToAction("Details", new { id = stationId });
        }

        #region Dummy Data Methods (Replace with real API/Repository calls later)

        private List<GasStationResultViewModel> GetDummyGasStations()
        {
            return new List<GasStationResultViewModel>
            {
                // MISSISSAUGA GAS STATIONS
                new GasStationResultViewModel
                {
                    StationId = 1,
                    Name = "Shell Square One",
                    Brand = "Shell",
                    Address = "100 City Centre Dr",
                    City = "Mississauga",
                    Province = "ON",
                    CurrentPrice = 1.459m,
                    DistanceFromRoute = 0.5,
                    EstimatedSavings = 2.50m,
                    Is24Hours = true,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-15),
                    Latitude = 43.5890,
                    Longitude = -79.6441,
                    ValueScore = 1.2
                },
                new GasStationResultViewModel
                {
                    StationId = 2,
                    Name = "Esso Dundas",
                    Brand = "Esso",
                    Address = "2555 Dundas St W",
                    City = "Mississauga",
                    Province = "ON",
                    CurrentPrice = 1.479m,
                    DistanceFromRoute = 1.2,
                    EstimatedSavings = 1.20m,
                    Is24Hours = false,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-30),
                    Latitude = 43.5847,
                    Longitude = -79.6442,
                    ValueScore = 2.1
                },
                new GasStationResultViewModel
                {
                    StationId = 3,
                    Name = "Petro-Canada Hurontario",
                    Brand = "Petro-Canada",
                    Address = "3476 Hurontario St",
                    City = "Mississauga",
                    Province = "ON",
                    CurrentPrice = 1.439m,
                    DistanceFromRoute = 2.0,
                    EstimatedSavings = 3.80m,
                    Is24Hours = true,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-45),
                    Latitude = 43.5551,
                    Longitude = -79.6694,
                    ValueScore = 1.8
                },
                new GasStationResultViewModel
                {
                    StationId = 4,
                    Name = "Canadian Tire Gas+ Erin Mills",
                    Brand = "Canadian Tire",
                    Address = "5035 Erin Mills Pkwy",
                    City = "Mississauga",
                    Province = "ON",
                    CurrentPrice = 1.469m,
                    DistanceFromRoute = 0.8,
                    EstimatedSavings = 1.80m,
                    Is24Hours = false,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddHours(-1),
                    Latitude = 43.5282,
                    Longitude = -79.7398,
                    ValueScore = 1.5
                },
                new GasStationResultViewModel
                {
                    StationId = 5,
                    Name = "Costco Gas Bar Heartland",
                    Brand = "Costco",
                    Address = "6085 Mavis Rd",
                    City = "Mississauga",
                    Province = "ON",
                    CurrentPrice = 1.429m,
                    DistanceFromRoute = 3.5,
                    EstimatedSavings = 4.50m,
                    Is24Hours = false,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddHours(-2),
                    Latitude = 43.5653,
                    Longitude = -79.7316,
                    ValueScore = 2.5
                },
                new GasStationResultViewModel
                {
                    StationId = 6,
                    Name = "Pioneer Gas Airport",
                    Brand = "Pioneer",
                    Address = "6750 Mississauga Rd",
                    City = "Mississauga",
                    Province = "ON",
                    CurrentPrice = 1.449m,
                    DistanceFromRoute = 1.5,
                    EstimatedSavings = 2.80m,
                    Is24Hours = true,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-20),
                    Latitude = 43.6801,
                    Longitude = -79.6350,
                    ValueScore = 1.7
                },
                
                // OAKVILLE GAS STATIONS
                new GasStationResultViewModel
                {
                    StationId = 7,
                    Name = "Shell Oakville South",
                    Brand = "Shell",
                    Address = "2501 South Service Rd",
                    City = "Oakville",
                    Province = "ON",
                    CurrentPrice = 1.465m,
                    DistanceFromRoute = 0.7,
                    EstimatedSavings = 2.00m,
                    Is24Hours = true,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-10),
                    Latitude = 43.4501,
                    Longitude = -79.7479,
                    ValueScore = 1.4
                },
                new GasStationResultViewModel
                {
                    StationId = 8,
                    Name = "Esso Trafalgar",
                    Brand = "Esso",
                    Address = "1420 Trafalgar Rd",
                    City = "Oakville",
                    Province = "ON",
                    CurrentPrice = 1.485m,
                    DistanceFromRoute = 1.8,
                    EstimatedSavings = 0.80m,
                    Is24Hours = false,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-25),
                    Latitude = 43.4672,
                    Longitude = -79.7583,
                    ValueScore = 2.3
                },
                new GasStationResultViewModel
                {
                    StationId = 9,
                    Name = "Petro-Canada Oakville QEW",
                    Brand = "Petro-Canada",
                    Address = "1500 North Service Rd W",
                    City = "Oakville",
                    Province = "ON",
                    CurrentPrice = 1.445m,
                    DistanceFromRoute = 0.3,
                    EstimatedSavings = 3.20m,
                    Is24Hours = true,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-40),
                    Latitude = 43.4515,
                    Longitude = -79.7235,
                    ValueScore = 1.1
                },
                new GasStationResultViewModel
                {
                    StationId = 10,
                    Name = "Costco Gas Bar Oakville",
                    Brand = "Costco",
                    Address = "2499 North Service Rd",
                    City = "Oakville",
                    Province = "ON",
                    CurrentPrice = 1.425m,
                    DistanceFromRoute = 2.5,
                    EstimatedSavings = 5.00m,
                    Is24Hours = false,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddHours(-1),
                    Latitude = 43.4398,
                    Longitude = -79.7118,
                    ValueScore = 2.0
                },
                new GasStationResultViewModel
                {
                    StationId = 11,
                    Name = "Shell Lakeshore Oakville",
                    Brand = "Shell",
                    Address = "369 Lakeshore Rd E",
                    City = "Oakville",
                    Province = "ON",
                    CurrentPrice = 1.455m,
                    DistanceFromRoute = 1.0,
                    EstimatedSavings = 2.40m,
                    Is24Hours = true,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-35),
                    Latitude = 43.4507,
                    Longitude = -79.6835,
                    ValueScore = 1.6
                },
                new GasStationResultViewModel
                {
                    StationId = 12,
                    Name = "Pioneer Oakville Downtown",
                    Brand = "Pioneer",
                    Address = "155 Cross Ave",
                    City = "Oakville",
                    Province = "ON",
                    CurrentPrice = 1.475m,
                    DistanceFromRoute = 1.3,
                    EstimatedSavings = 1.50m,
                    Is24Hours = false,
                    FuelType = "Regular",
                    LastUpdated = DateTime.Now.AddMinutes(-50),
                    Latitude = 43.4470,
                    Longitude = -79.6752,
                    ValueScore = 1.9
                }
            };
        }

        private GasStationDetailViewModel GetDummyStationDetails(int id)
        {
            // Simulate getting station by ID
            var allStations = GetDummyGasStations();
            var station = allStations.FirstOrDefault(s => s.StationId == id);

            if (station == null)
                return null;

            return new GasStationDetailViewModel
            {
                StationId = station.StationId,
                Name = station.Name,
                Brand = station.Brand,
                Address = station.Address,
                City = station.City,
                Province = station.Province,
                PostalCode = station.City == "Mississauga" ? "L5B 1M2" : "L6H 0H3",
                PhoneNumber = "(905) 555-" + (1000 + station.StationId).ToString(),
                Latitude = station.Latitude,
                Longitude = station.Longitude,
                CurrentPrice = station.CurrentPrice,
                LastUpdated = station.LastUpdated,
                DistanceFromRoute = station.DistanceFromRoute,
                EstimatedDetourTime = (int)(station.DistanceFromRoute * 2), // 2 minutes per km
                EstimatedSavings = station.EstimatedSavings,
                AveragePriceInArea = 1.489m,
                Is24Hours = station.Is24Hours,
                FuelType = station.FuelType,
                StartLocation = "Mississauga, ON",
                EndLocation = "Oakville, ON",
                NearbyStations = GetNearbyStations(id, allStations)
            };
        }

        private List<NearbyStationViewModel> GetNearbyStations(int currentStationId, List<GasStationResultViewModel> allStations)
        {
            return allStations
                .Where(s => s.StationId != currentStationId)
                .Take(3)
                .Select(s => new NearbyStationViewModel
                {
                    StationId = s.StationId,
                    Name = s.Name,
                    Brand = s.Brand,
                    CurrentPrice = s.CurrentPrice,
                    DistanceFromRoute = s.DistanceFromRoute
                })
                .ToList();
        }

        #endregion
    }
}