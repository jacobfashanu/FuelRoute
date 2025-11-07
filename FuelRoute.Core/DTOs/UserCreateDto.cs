using System.ComponentModel.DataAnnotations;

namespace FuelRoute.Core;

public class UserCreateDto
{
        
    [Required]
    public Models.TaskStatus Status { get; set; } = Models.TaskStatus.Pending;
    public DateTime? DueDate { get; set; }
}
