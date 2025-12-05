using System.Threading.Tasks;

namespace FuelRoute.Core.Interfaces
{
    public interface IAuthService
    {
        Task<FuelRoute.Core.DTOs.AuthResultDto> LoginAsync(FuelRoute.Core.DTOs.LoginDto dto);
        Task<FuelRoute.Core.DTOs.AuthResultDto> RegisterAsync(FuelRoute.Core.DTOs.UserCreateDto dto);
    }
}
