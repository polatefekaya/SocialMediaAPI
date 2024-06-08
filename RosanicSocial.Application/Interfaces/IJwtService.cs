using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RosanicSocial.Application.Interfaces {
    public interface IJwtService {
        AuthenticationResponse CreateJwtToken(AuthenticationRequest request);
        ClaimsPrincipal? GetClaimsPrincipal(string? token);
        Task<AuthenticationResponse?> GenerateNewAccessToken(TokenModel model);
    }
}
