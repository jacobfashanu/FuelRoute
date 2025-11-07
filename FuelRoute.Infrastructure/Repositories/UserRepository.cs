using FuelRoute.Core.Interfaces;
using FuelRoute.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FuelRoute.Infrastructure.Repositories
{
    // The UserRepository implements the IUserRepository interface.
    // It contains EF Core logic to perform operations on the Users
    public class UserRepository : IUserRepository
    {
        // The EF Core database context gives access to the database tables.
        private readonly FuelRouteDbContext _context;

        // Constructor Dependency Injection:
        // The context is injected by the DI container when UserRepository is created.  
        public UserRepository(FuelRouteDbContext context)
        {
            _context = context;
        }

        // READ ALL USERS
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            // Converts all records in the 'Users' DbSet into a list asynchronously
            return await _context.Users.ToListAsync();
        }

        // READ ONE USER BY ID
        public async Task<User?> GetByIdAsync(Guid id)
        {
            // Finds a user by its primary key (Guid).
            // Returns null if no matching record exists.
            return await _context.Users.FindAsync(id);
        }

        // CREATE NEW USER
        public async Task AddAsync(User user)
        {
            // Adds the user object to the Users DbSet (for insert).
            _context.Users.Add(user);

            // Saves all pending changes to the database
            await _context.SaveChangesAsync();
        }

        // UPDATE EXISTING USER
        public async Task UpdateAsync(User user)
        {
            // Marks the given user entity as modified.
            _context.Users.Update(user);

            // Saves all pending changes to the database.
            await _context.SaveChangesAsync();
        }

        // DELETE USER
        public async Task DeleteAsync(Guid id)
        {
            // Looks up the user first by ID.
            var user = await _context.Users.FindAsync(id);

            // If found, remove it from the DbSet and save the change.
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
