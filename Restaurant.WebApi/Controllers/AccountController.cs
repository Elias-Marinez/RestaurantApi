using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Interfaces.Services;

namespace Restaurant.WebApi.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpPost("Register Waiter")]
        public async Task<IActionResult> RegisterWaiterAsync(RegisterRequest request)
        {
            return Ok(await _accountService.RegisterWaiterAsync(request));
        }

        [HttpPost("Register Administrator")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            return Ok(await _accountService.RegisterAdministratorAsync(request));
        }

    }
}
