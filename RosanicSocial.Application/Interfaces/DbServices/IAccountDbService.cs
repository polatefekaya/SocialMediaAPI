using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Domain.DTO.Request.Account;
using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Request.Authentication.Password;
using RosanicSocial.Domain.DTO.Request.Verification.Email;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.Domain.DTO.Response.Authentication.Response;
using RosanicSocial.Domain.DTO.Response.Email;
using RosanicSocial.Domain.DTO.Response.Verification.Email;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IAccountDbService {
        Task<AuthenticationResponse?> Register(RegisterRequest request);
        Task<ApplicationUser?> Login(LoginRequest request);
        Task Logout();
        Task<ApplicationUser?> IsUsernameAlreadyRegistered(string username);
        Task<EmailSendResponse?> SendTwoFactorAuth(LoginRequest? request = null);
        Task<TwoFactorManageResponse?> ManageTwoFactorLogIn(TwoFactorManageRequest request);
        Task<TwoFactorVerificationResponse?> VerifyTwoFactorToken(TwoFactorVerificationRequest request);
        Task<EmailSendResponse?> SendConfirmationEmail();
        Task<EmailConfirmResponse?> ConfirmEmail(EmailConfirmRequest request);
        Task<EmailSendResponse?> ForgotPassword(ForgotPasswordRequest request);
        Task<ResetForgottenPasswordResponse?> ResetForgottenPassword(ResetForgottenPasswordRequest request);
        Task<ChangePasswordResponse?> ChangePassword(ChangePasswordRequest request);
    }
}
