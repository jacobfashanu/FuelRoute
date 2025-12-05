using System;
using System.ComponentModel.DataAnnotations;

namespace FuelRoute.Web.Models
{
    public class GasStationResultViewModel
    {
        public int StationId { get; set; }
        
        [Required]
        [Display(Name = "Station Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string Province { get; set; }
        
        [Display(Name = "Current Price ($/L)")]
        [DisplayFormat(DataFormatString = "{0:F3}")]
        public decimal CurrentPrice { get; set; }
        
        [Display(Name = "Distance from Route (km)")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double DistanceFromRoute { get; set; }
        
        [Display(Name = "Estimated Savings")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal EstimatedSavings { get; set; }
        
        [Display(Name = "Open 24 Hours")]
        public bool Is24Hours { get; set; }
        
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }
        
        // Coordinates for Google Maps
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        // Calculated field for ranking/sorting
        public double ValueScore { get; set; }
    }
}