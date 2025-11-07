using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRoute.Core.Models
{
    public class UserSettings
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int MaxDetour { get; set; }
        [Required]
        public bool EnableNotification { get; set; }
        [Required]
        public bool DarkTheme { get; set; }
    }
}