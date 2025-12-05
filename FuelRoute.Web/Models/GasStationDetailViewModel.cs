using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelRoute.Web.Models
{
    public class GasStationDetailViewModel
    {
        public int StationId { get; set; }
        
        [Required]
        [Display(Name = "Station Name")]
        public string Name { get; set; }
        
        [Required]
        public string Brand { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string Province { get; set; }
        
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        // Location coordinates
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        // Pricing information
        [Display(Name = "Current Price ($/L)")]
        [DisplayFormat(DataFormatString = "{0:F3}")]
        public decimal CurrentPrice { get; set; }
        
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }
        
        // Route-related information
        [Display(Name = "Distance from Route (km)")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double DistanceFromRoute { get; set; }
        
        [Display(Name = "Estimated Detour Time (min)")]
        public int? EstimatedDetourTime { get; set; }
        
        // Savings calculation
        [Display(Name = "Estimated Savings")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal EstimatedSavings { get; set; }
        
        [Display(Name = "Average Price in Area")]
        [DisplayFormat(DataFormatString = "{0:F3}")]
        public decimal? AveragePriceInArea { get; set; }
        
        // Station features
        [Display(Name = "Open 24 Hours")]
        public bool Is24Hours { get; set; }
        
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        
        // Nearby stations for comparison
        public List<NearbyStationViewModel> NearbyStations { get; set; }
        
        // User's route information (optional)
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }

    // Supporting ViewModel for nearby stations
    public class NearbyStationViewModel
    {
        public int StationId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal CurrentPrice { get; set; }
        public double DistanceFromRoute { get; set; }
    }
}