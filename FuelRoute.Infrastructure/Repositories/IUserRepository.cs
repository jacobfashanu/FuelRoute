using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FuelRoute.Core.Models;

namespace FuelRoute.Core.Interfaces;

// Contract for data operations on User entities.
public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    // Needed for login: lookup by email address.
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}