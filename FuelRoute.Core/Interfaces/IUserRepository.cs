using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FuelRoute.Core.Models;

namespace FuelRoute.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
