
using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Infrastructure.Identity.Entities;
using Restaurant.Infrastructure.Identity.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace Restaurant.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService;

        public AccountService(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            AuthenticationResponse response = new();

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                response.HasError = true;
                response.Error = $"No hay cuentas registradas con {request.UserName}";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"Credenciales invalidas para {request.UserName}";
                return response;
            }

            JwtSecurityToken token = await _jwtService.GenerateJWToken(user);

            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(token);
            response.RefreshToken = _jwtService.GenerateRefreshToken().Token;
            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = roles.ToList();

            return response;
        }
        public async Task<RegisterResponse> RegisterAdministratorAsync(RegisterRequest request)
        {
            RegisterResponse response = new();

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"Nombre de Usuario '{request.UserName}' ya ha sido tomado.";
                return response;
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                response.HasError = true;
                response.Error = $"Email '{request.Email}' ya ha sido registrado.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Administrator.ToString());
            }
            else
            {
                response.HasError = true;
                response.Error = $"Ha ocurrido un error al registrar el usuario";
                return response;
            }

            return response;
        }
        public async Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request)
        {
            RegisterResponse response = new();

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                response.HasError = true;
                response.Error = $"Nombre de Usuario '{request.UserName}' ya ha sido tomado.";
                return response;
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                response.HasError = true;
                response.Error = $"Email '{request.Email}' ya ha sido registrado.";
                return response;
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Waiter.ToString());
            }
            else
            {
                response.HasError = true;
                response.Error = $"Ha ocurrido un error al registrar el usuario";
                return response;
            }

            return response;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
