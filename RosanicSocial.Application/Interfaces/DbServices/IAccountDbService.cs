using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Domain.DTO.Request.Account;
using RosanicSocial.Domain.DTO.Response.Authentication;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IAccountDbService {
        Task<AuthenticationResponse?> Register(RegisterRequest request);
        Task<ApplicationUser?> Login(LoginRequest request);
        Task Logout();
        Task<ApplicationUser?> IsUsernameAlreadyRegistered(string username);
    }
}
