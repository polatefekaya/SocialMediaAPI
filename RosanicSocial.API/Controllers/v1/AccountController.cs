using Asp.Versioning;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Domain.DTO.Request.Account;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AccountController : CustomControllerBase {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IJwtService jwtService, ILogger<AccountController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager) {
            _userManger = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Register(RegisterRequest request) {
            _logger.LogInformation("Register Controller started");
            _logger.LogDebug($"Request Type: {nameof(RegisterRequest)}");

            if (!ModelState.IsValid) {
                string errorMessage = string.Join(" | ", 
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Problem(errorMessage);
            }

            ApplicationUser user = new ApplicationUser() {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Username
            };
            IdentityResult result = await _userManger.CreateAsync(user, request.Password);

            if (result.Succeeded) {
                await _signInManager.SignInAsync(user, isPersistent: false);

                AuthenticationResponse authResponse = _jwtService.CreateJwtToken(user.ToAuthRequest());

                user.RefreshToken = authResponse.RefreshToken;
                user.RefreshTokenExpiration = authResponse.RefreshTokenExpiration;

                await _userManger.UpdateAsync(user);

                return Ok(authResponse);
            }

            string errorDesc = string.Join(" | ", result.Errors.Select(x => x.Description));
            return Problem(errorDesc);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request) {
            _logger.LogInformation("Login Controller started");
            _logger.LogDebug($"Request Type: {nameof(LoginRequest)}");

            if (!ModelState.IsValid) {
                string errorMessage = string.Join(" | ",
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Problem(errorMessage);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = 
                await _signInManager.PasswordSignInAsync(
                    request.UserName, request.Password, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded) {
                ApplicationUser? user = await _userManger.FindByNameAsync(request.UserName);

                if (user == null) {
                    return NoContent();
                }

                return Ok(new {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = request.UserName
                });
            } else {
                return Problem("Invalid Username or Password");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            _logger.LogInformation("Logout Controller started");
            _logger.LogDebug($"Request Type: GET");

            await _signInManager.SignOutAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> IsUsernameAlreadyRegistered(string usernanme) {
            _logger.LogInformation("IsUsernameAlreadyRegistered Controller started");
            _logger.LogDebug($"Request Type: GET");

            ApplicationUser? user = await _userManger.FindByNameAsync(usernanme);

            if (user == null) {
                return Ok(true);
            } else {
                return Ok(false);
            }
        }
    }
}
