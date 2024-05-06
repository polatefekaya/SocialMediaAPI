using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Domain.Data.Services.JwtService;
using RosanicSocial.Domain.DTO.Request.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RosanicSocial.Application.Interfaces.Helpers {
    public interface IJwtHelperService {
        DateTime SetExpiration(JwtServiceData.Expirations expirations);
        Claim[] SetClaims(ref AuthenticationRequest request);
        SymmetricSecurityKey SetSecurityKey();
        SigningCredentials SetSigningCredentials(ref SymmetricSecurityKey securityKey);
        public JwtSecurityToken SetSecurityTokenGenerator(ref Claim[] claims, ref DateTime expiration, ref SigningCredentials signingCredentials);
        string GenerateToken(ref JwtSecurityToken securityToken);
        string GenerateRefreshToken();
        ClaimsPrincipal ValidateToken(string token, ref TokenValidationParameters validationParameters, out SecurityToken securityToken);
    }

}
