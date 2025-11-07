using FuelRoute.Core.Models;

namespace FuelRoute.Core.Interfaces
{
    // The repository interface defines what operations can be done on User entities.
    // It represents the contract between the Core and Infrastructure layers.
    // This helps keep the Core independent of any specific database technology (EF Core, etc.)
    public interface IUserRepository
    {
        // Returns all users from the data source as an asynchronous operation.
        Task<IEnumerable<User>> GetAllAsync();

        // Retrieves a single user based on their unique Guid identifier.
        // Returns null(?) if no user is found.
        Task<User?> GetByIdAsync(Guid id);

        // Adds a new user to the data source.
        // 'async' allows the database call to run without blocking the main thread.
        Task AddAsync(User user);

        // Updates an existing user record in the data source.
        Task UpdateAsync(User user);

        // Deletes a user by their Guid identifier.
        Task DeleteAsync(Guid id);
    }
}
