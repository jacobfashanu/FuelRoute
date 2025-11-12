using FuelRoute.Core.Models;
namespace FuelRoute.Core.Interfaces;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task<Car> CreateAsync(TaskItem task);
    Task<Car?> UpdateAsync(TaskItem task);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);

}
