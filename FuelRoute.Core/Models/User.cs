using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace FuelRoute.Core.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, StringLength(35)]
        public string FirstName { get; set; } = string.Empty;
        [Required, StringLength(35)]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Use format: 905-123-4567")]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).+$",
        ErrorMessage = "Password must include upper, lower, number, and special character.")]
        public string Password { get; set; } = string.Empty;
        // Add hashing and salting later
    }
}