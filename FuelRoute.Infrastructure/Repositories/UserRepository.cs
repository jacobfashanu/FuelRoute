using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FuelRoute.Core.Interfaces;
using FuelRoute.Core.Models;
using FuelRoute.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FuelRoute.Infrastructure.Repositories
{
    // The UserRepository implements the IUserRepository interface.
    // It contains EF Core logic to perform operations on Users.
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ ALL USERS
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        // READ ONE USER BY ID
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        // READ ONE USER BY EMAIL (for login)
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        // CREATE NEW USER
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // UPDATE EXISTING USER
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // DELETE USER
        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
