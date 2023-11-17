
using Restaurant.Core.Application.Dtos.Account;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterAdministratorAsync(RegisterRequest request);
        Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request);
        Task SignOutAsync();
    }
}
