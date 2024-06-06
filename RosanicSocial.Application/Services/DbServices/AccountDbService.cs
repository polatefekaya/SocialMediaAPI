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
using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Request.Authentication.Password;
using RosanicSocial.Domain.DTO.Request.Email;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Request.Verification.Email;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.Domain.DTO.Response.Authentication.Response;
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

            } else if (result.RequiresTwoFactor) {
                await SendTwoFactorAuth(request);
                _logger.LogInformation("Two Factor Authentication Code is Sent.");
                return null;

            } else {
                _logger.LogError("Password and Username not matching.");
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
            _logger.LogDebug($"{nameof(ConfirmEmail)} in {nameof(AccountDbService)} is started with UserId:{request.UserId}, Token:{request.Token} parameters.");
            if (string.IsNullOrEmpty(request.UserId)) {
                _logger.LogError($"UserId in {nameof(EmailConfirmRequest)} is null or empty.");
                return null;
            }
            if (string.IsNullOrEmpty(request.Token)) {
                _logger.LogError($"Token in {nameof(EmailConfirmRequest)} is null or empty.");
                return null;
            }

            ApplicationUser? user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null) {
                _logger.LogError($"Can't find any user with UserId:{request.UserId}");
                return null;
            }

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, request.Token);
            if (result.Succeeded) {
                _logger.LogInformation($"Email confirmed for UserId:{request.UserId}");
                EmailConfirmResponse response = new EmailConfirmResponse {

                };
                return response;
            }

            _logger.LogError($"Email can't be confirmed for UserId:{request.UserId}");
            return null;    
        }


        public async Task<EmailSendResponse?> SendTwoFactorAuth(LoginRequest? request = null) {
            ApplicationUser? user;
            if (request is not null) {
                user = await _userManager.FindByNameAsync(request.UserName);
                bool passwordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!passwordCorrect) {
                    _logger.LogError("Password is not Correct.");
                    return null;
                }
            } else {
                user = await GetCurrentUser();
            }
            if (user is null) {
                _logger.LogError("User not found");
                return null;
            }

            EmailSendTwoFactorRequest twoFactorRequest = new EmailSendTwoFactorRequest {
                UserId = user.Id,
                From = _configuration["EmailOptions:TwoFactorAuthSender"],
                To = user.Email,
                OTPToken = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider)
            };

            EmailSendResponse? response = await _emailSenderService.SendTwoFactorEmail(twoFactorRequest);
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

        public async Task<TwoFactorVerificationResponse?> VerifyTwoFactorToken(TwoFactorVerificationRequest request) {
            ApplicationUser? user;
            if (request is not null) {
                user = await _userManager.FindByNameAsync(request.UserName);
                bool passwordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);

                if (!passwordCorrect) {
                    _logger.LogError("Password is not Correct.");
                    return null;
                }
            } else {
                user = await GetCurrentUser();
            }
            if (user is null) {
                _logger.LogError("User not found");
                return null;
            }

            bool isVerfied = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, request.Token);
            if (isVerfied) {
                _logger.LogInformation($"Sucessfully Verified the 2FA Token.");
            } else {
                _logger.LogError("2FA Token Can not Verified.");
            }

            TwoFactorVerificationResponse response = new TwoFactorVerificationResponse {
                Token = request.Token,
                isVerified = isVerfied
            };

            if (isVerfied) {
                await _signInManager.SignInAsync(user, false);
                _logger.LogInformation($"Sign in with 2FA is successfull.");
            }

            return response;
        }

        private string? GetCurrentUserId() {
            return _context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private async Task<ApplicationUser?> GetCurrentUser() {
            ApplicationUser? user = await _userManager.GetUserAsync(_context.HttpContext?.User);
            if (user is null) {
                _logger.LogError($"No User with this:{GetCurrentUserId()} Id");
                return null;
            }

            return user;
        }

        public async Task<TwoFactorManageResponse?> ManageTwoFactorLogIn(TwoFactorManageRequest request) {
            _logger.LogDebug($"{nameof(ManageTwoFactorLogIn)} in {nameof(AccountDbService)} is started.");

            ApplicationUser? user = await GetCurrentUser();
            if (user is null) {
                _logger.LogError("There is no User");
                return null;
            }

            bool isVerified = await _userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, request.Token);

            if (!isVerified) {
                _logger.LogError("2FA Token Can not Be Verified.");
                return null;
            }

            if (user.TwoFactorEnabled) {
                _logger.LogInformation($"2FA Disabled For UserId:{user.Id}");
                user.TwoFactorEnabled = false;
            } else {
                _logger.LogInformation($"2FA Enabled For UserId:{user.Id}");
                user.TwoFactorEnabled = true;
            }

            await _userManager.UpdateAsync(user);

            TwoFactorManageResponse response = new TwoFactorManageResponse { 
                Token = request.Token,
                isTwoFactorEnabled = user.TwoFactorEnabled,
                isVerified = isVerified
            };

            _logger.LogInformation($"{nameof(ManageTwoFactorLogIn)} in {nameof(AccountDbService)} is finished.");
            return response;
        }

        public async Task<EmailSendResponse?> ForgotPassword(ForgotPasswordRequest request) {
            _logger.LogDebug($"{nameof(ForgotPassword)} in {nameof(AccountDbService)} is started.");

            //we have to send an email with a token
            ApplicationUser? user = await _userManager.FindByNameAsync(request.UserName);
            if (user is null) {
                _logger.LogError($"There is no user with UserName:{request.UserName}");
                return null;
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            ActionContext actionContext = _actionContextAccessor.ActionContext;
            IUrlHelper _urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);

            string? confirmationLink = UrlHelperExtensions.Action(_urlHelper, "ResetForgottenPassword", "Account", new { UserName = user.UserName, Token = token }, protocol: _context.HttpContext?.Request.Scheme);
            if (confirmationLink is null) {
                _logger.LogError("Confirmation link is null.");
                return null;
            }

            EmailSendResetPasswordRequest emailSendResetPasswordRequest = new EmailSendResetPasswordRequest {
                From = _configuration["EmailOptions:TwoFactorAuthSender"],
                To = user.Email,
                ConfirmationLink = confirmationLink
            };

            EmailSendResponse? response = await _emailSenderService.SendResetPasswordEmail(emailSendResetPasswordRequest);

            _logger.LogInformation($"{nameof(ForgotPassword)} in {nameof(AccountDbService)} is finished.");
        }

        public Task<ResetForgottenPasswordResponse?> ResetForgottenPassword(ResetForgottenPasswordRequest request) {
            _logger.LogDebug($"{nameof(ResetForgottenPassword)} in {nameof(AccountDbService)} is started.");
            _logger.LogInformation($"{nameof(ResetForgottenPassword)} in {nameof(AccountDbService)} is finished.");
            return null;
        }

        public Task<ChangePasswordResponse?> ChangePassword(ChangePasswordRequest request) {
            _logger.LogDebug($"{nameof(ChangePassword)} in {nameof(AccountDbService)} is started.");
            _logger.LogInformation($"{nameof(ChangePassword)} in {nameof(AccountDbService)} is finished.");
            return null;
        }
    }
}
