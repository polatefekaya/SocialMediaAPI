using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Domain.DTO.Request.Account;
using RosanicSocial.Domain.DTO.Request.Email;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Request.Verification.Email;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.Domain.DTO.Response.Email;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Info.Detailed;
using RosanicSocial.Domain.DTO.Response.Verification.Email;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RosanicSocial.Application.Services.DbServices {
    public class AccountDbService : IAccountDbService {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly IUserInfoDbService _userInfoDbService;

        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _context;
        private readonly IConfiguration _configuration;

        private readonly ILogger<AccountDbService> _logger; 

        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        public AccountDbService(ILogger<AccountDbService> logger, UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IActionContextAccessor actionContextAccessor, IUrlHelperFactory urlHelperFactory, IJwtService jwtService, IUserInfoDbService userInfoDbService, IEmailSenderService emailSenderService, IHttpContextAccessor context, IConfiguration configuration) {
            _userManager = userManger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _userInfoDbService = userInfoDbService;
            _logger = logger;
            _emailSenderService = emailSenderService;
            _context = context;
            _configuration = configuration;

            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
        }

        public async Task<ApplicationUser?> IsUsernameAlreadyRegistered(string username) {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<ApplicationUser?> Login(LoginRequest request) {
            Microsoft.AspNetCore.Identity.SignInResult result =
                await _signInManager.PasswordSignInAsync(
                    request.UserName, request.Password, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded) {
                ApplicationUser? user = await _userManager.FindByNameAsync(request.UserName);
                return user;

            } else {
                _logger.LogError("Password and Username not matching");
                return null;
            }
        }

        public async Task Logout() {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest request) {
            ApplicationUser user = new ApplicationUser() {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded) {
                await _signInManager.SignInAsync(user, isPersistent: false);

                AuthenticationResponse authResponse = _jwtService.CreateJwtToken(user.ToAuthRequest());

                user.RefreshToken = authResponse.RefreshToken;
                user.RefreshTokenExpiration = authResponse.RefreshTokenExpiration;

                await _userManager.UpdateAsync(user);

                //CreateInfos
                BaseInfoAddResponse baseInfoResponse = await _userInfoDbService.AddBaseInfo(new BaseInfoAddRequest { UserId = user.Id });
                DetailedInfoAddResponse detailedInfoResponse = await _userInfoDbService.AddDetailedInfo(new DetailedInfoAddRequest { UserId = user.Id });

                return authResponse;
            }

            string errorDesc = string.Join(" | ", result.Errors.Select(x => x.Description));
            _logger.LogError(errorDesc);
            return null;
        }

        public async Task<EmailSendResponse?> SendConfirmationEmail() {
            ApplicationUser? user = await GetCurrentUser();
            if (user is null) {
                return null;
            }

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            ActionContext actionContext = _actionContextAccessor.ActionContext;
            IUrlHelper _urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);

            string? confirmationLink = UrlHelperExtensions.Action(_urlHelper ,"ConfirmEmail","Account", new {UserId = user.Id, Token = token}, protocol: _context.HttpContext?.Request.Scheme);
            if (confirmationLink is null) {
                return null;
            }


            EmailSendVerificationRequest emailRequest = new EmailSendVerificationRequest {
                From = _configuration["EmailOptions:TwoFactorAuthSender"],
                To = user.Email,
                Name = FirstCharToUpperStringCreate(user.FirstName),
                ConfirmationLink = confirmationLink
            };

            EmailSendResponse? response = await _emailSenderService.SendVerificationEmail(emailRequest);
            if (response is null) {
                return null;
            }

            return response;
        }

        public async Task<EmailConfirmResponse?> ConfirmEmail(EmailConfirmRequest request) {
            _logger.LogDebug($"This is worked UserId:{request.UserId}, Token:{request.Token}");
            return null;
        }


        public async Task<EmailSendResponse?> SetTwoFactorAuth() {
            ApplicationUser? user = await GetCurrentUser();
            if (user is null) {
                return null;
            }

            EmailSendRequest request = new EmailSendRequest {
                From = _configuration["EmailOptions:TwoFactorAuthSender"],
                To = user.Email,
                Subject = "Two Factor Authentication Verification",
                PlainTextContent = $"{788521}"
            };

            EmailSendResponse? response = await _emailSenderService.SendEmail(request);
            return response;
        }
        private string FirstCharToUpperStringCreate(string? input) {
            if (string.IsNullOrEmpty(input)) {
                return string.Empty;
            }

            return string.Create(input.Length, input, static (Span<char> chars, string str) =>
            {
                chars[0] = char.ToUpperInvariant(str[0]);
                str.AsSpan(1).CopyTo(chars[1..]);
            });
        }

        public Task<EmailSendResponse?> VerifyTwoFactorToken(string token) {
            throw new NotImplementedException();
        }

        private string? GetCurrentUserId() {
            return _context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private async Task<ApplicationUser?> GetCurrentUser() {
            string? currentUserId = GetCurrentUserId();
            if (currentUserId is null) {
                _logger.LogError("Not Signed In");
                return null;
            }

            ApplicationUser? user = await _userManager.FindByIdAsync(currentUserId);
            if (user is null) {
                _logger.LogError($"No User with this:{currentUserId} Id");
                return null;
            }

            return user;
        }
    }
}
