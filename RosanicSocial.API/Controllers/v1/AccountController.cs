using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RosanicSocial.Application.Filters;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Domain.DTO.Request.Account;
using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Request.Email;
using RosanicSocial.Domain.DTO.Request.Verification.Email;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.Domain.DTO.Response.Email;
using RosanicSocial.Domain.DTO.Response.Verification.Email;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AccountController : CustomControllerBase {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountDbService _accountDbService;
        private readonly IEmailSenderService _emailSenderService;

        public AccountController(IAccountDbService accountDbService, ILogger<AccountController> logger, IEmailSenderService emailSenderService) {
            _logger = logger;
            _accountDbService = accountDbService;
            _emailSenderService = emailSenderService;
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

            AuthenticationResponse? authRespose = await _accountDbService.Register(request);

            if (authRespose != null) {
                return Ok(authRespose);
            }
            return Problem("Error occured while registering");
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

            ApplicationUser? user = await _accountDbService.Login(request);

            if (user != null) {
                return Ok(new {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName
                });
            }
            return Problem("Password and UserName is not Matching");
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            _logger.LogInformation("Logout Controller started");
            _logger.LogDebug($"Request Type: GET");

            await _accountDbService.Logout();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> IsUsernameAlreadyRegistered(string usernanme) {
            _logger.LogInformation("IsUsernameAlreadyRegistered Controller started");
            _logger.LogDebug($"Request Type: GET");

            ApplicationUser? user = await _accountDbService.IsUsernameAlreadyRegistered(usernanme);
            return Ok(user == null);
        }

        [HttpPost]
        public async Task<IActionResult> SendTwoFactorAuth() {
            //Create token and send it via email
            //wait user for verify
            EmailSendResponse? response = await _accountDbService.SendTwoFactorAuth();
            if (response is null) {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ManageTwoFactorVerification(TwoFactorManageRequest request) {
            TwoFactorManageResponse? response = await _accountDbService.ManageTwoFactorLogIn(request);
            if (response is null) {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyTwoFactorAuth(TwoFactorVerificationRequest request) {
            TwoFactorVerificationResponse? response = await _accountDbService.VerifyTwoFactorToken(request);
            if (response is null) {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SendConfirmationEmail() {
            //has to be logged in
            EmailSendResponse? response = await _accountDbService.SendConfirmationEmail();
            if (response is null) {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] EmailConfirmRequest request) {
            EmailConfirmResponse? response = await _accountDbService.ConfirmEmail(request);
            if (response is null) {
                return BadRequest();
            }
            return Ok(response);
        }

    }
}
