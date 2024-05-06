using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.Helpers;
using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.Domain.Data.Services.JwtService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RosanicSocial.Application.Services {
    public class JwtService : IJwtService {
        private readonly IConfiguration _configuration;
        private readonly IJwtHelperService _jwtHelperService;
        public JwtService(IConfiguration configuration, IJwtHelperService jwtHelperService) {
            _configuration = configuration;
            _jwtHelperService = jwtHelperService;
        }

        public AuthenticationResponse CreateJwtToken(AuthenticationRequest request) {
            DateTime tokenExpiration = _jwtHelperService.SetExpiration(JwtServiceData.Expirations.Token);
            DateTime refreshTokenExpiration = _jwtHelperService.SetExpiration(JwtServiceData.Expirations.RefreshToken);

            Claim[] claims = _jwtHelperService.SetClaims(ref request);
            SymmetricSecurityKey securityKey = _jwtHelperService.SetSecurityKey();
            SigningCredentials signingCredentials = _jwtHelperService.SetSigningCredentials(ref securityKey);
            JwtSecurityToken securityToken = _jwtHelperService.SetSecurityTokenGenerator(ref claims, ref tokenExpiration, ref signingCredentials);

            string token = _jwtHelperService.GenerateToken(ref securityToken);
            string refreshToken = _jwtHelperService.GenerateRefreshToken();

            return new AuthenticationResponse {
                Username = request.Username,
                Email = request.Email,
                Expiration = tokenExpiration,
                Name = request.Name,
                Token = token,
                RefreshToken = refreshToken,
                RefreshTokenExpiration = refreshTokenExpiration
            };
        }

        public ClaimsPrincipal? GetClaimsPrincipal(string? token) {
            TokenValidationParameters validationParameters = new TokenValidationParameters() {
                ValidateAudience = true,
                ValidAudience = _configuration[JwtServiceData.jwtDataDictionary[JwtServiceData.Expirations.Audience]],
                ValidateIssuer = true,
                ValidIssuer = _configuration[JwtServiceData.jwtDataDictionary[JwtServiceData.Expirations.Issuer]],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _jwtHelperService.SetSecurityKey(),
                ValidateLifetime = false
            };

            ClaimsPrincipal principal = _jwtHelperService.ValidateToken(token, ref validationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken
                || jwtSecurityToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase
                    )) {
                throw new SecurityTokenException("InvalidToken");
            }

            return principal;
        }
    }
}
