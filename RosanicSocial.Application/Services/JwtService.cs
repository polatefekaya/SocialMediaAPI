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
using Microsoft.Extensions.Logging;

namespace RosanicSocial.Application.Services {
    public class JwtService : IJwtService {
        private readonly IConfiguration _configuration;
        private readonly IJwtHelperService _jwtHelperService;
        private readonly ILogger<JwtService> _logger;
        public JwtService(IConfiguration configuration, IJwtHelperService jwtHelperService, ILogger<JwtService> logger) {
            _configuration = configuration;
            _jwtHelperService = jwtHelperService;
            _logger = logger;
        }

        public AuthenticationResponse CreateJwtToken(AuthenticationRequest request) {
            _logger.LogTrace($"JwtToken Creation is Started for {request.Username}");

            DateTime tokenExpiration = _jwtHelperService.SetExpiration(JwtServiceData.Expirations.Token);
            _logger.LogDebug("Token Expiration is setted");

            DateTime refreshTokenExpiration = _jwtHelperService.SetExpiration(JwtServiceData.Expirations.RefreshToken);
            _logger.LogDebug("RefreshToken Expiration is setted");

            Claim[] claims = SetClaimsWithLog(ref request);
            _logger.LogDebug("Claims setted");

            SymmetricSecurityKey securityKey = _jwtHelperService.SetSecurityKey();
            _logger.LogDebug("SymmetricSecurityKey is setted");

            SigningCredentials signingCredentials = _jwtHelperService.SetSigningCredentials(ref securityKey);
            _logger.LogDebug("SigningCredentials are setted");

            JwtSecurityToken securityToken = _jwtHelperService.SetSecurityTokenGenerator(ref claims, ref tokenExpiration, ref signingCredentials);
            _logger.LogDebug("JwtSecurityToken (used for generation) is setted");

            string token = _jwtHelperService.GenerateToken(ref securityToken);
            _logger.LogDebug("Token is generated and setted");

            string refreshToken = _jwtHelperService.GenerateRefreshToken();
            _logger.LogDebug("RefreshToken is generated and setted");

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
            if (token is null) {
                _logger.LogError("Supplied token for GetClaimsPrincipal is null");
                return null;
            }
            TokenValidationParameters validationParameters = new TokenValidationParameters() {
                ValidateAudience = true,
                ValidAudience = _configuration[JwtServiceData.jwtDataDictionary[JwtServiceData.Expirations.Audience]],
                ValidateIssuer = true,
                ValidIssuer = _configuration[JwtServiceData.jwtDataDictionary[JwtServiceData.Expirations.Issuer]],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _jwtHelperService.SetSecurityKey(),
                ValidateLifetime = false
            };
            _logger.LogDebug("TokenValidatonParameters object created");
            _logger.LogTrace($"Valid Audience: {validationParameters.ValidAudience}\nValid Issuer: {validationParameters.ValidIssuer}\nValidateIssuerSignInKey: {validationParameters.ValidateIssuerSigningKey}\nValidateLifetime: {validationParameters.ValidateLifetime}");

            ClaimsPrincipal principal = _jwtHelperService.ValidateToken(token, ref validationParameters, out SecurityToken securityToken);
            _logger.LogDebug("ClaimsPrincipal object created via ValidateToken");

            JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken is null) {
                _logger.LogError("jwtSecurityToken is null");
                throw new SecurityTokenException("Invalid Token");
            }

            bool isAlgorithmsNotMatch = jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms
                .HmacSha256, StringComparison.InvariantCultureIgnoreCase);

            if (isAlgorithmsNotMatch) {
                _logger.LogError("jwtSecurityToken algorithm not matching with securityToken");
                throw new SecurityTokenException("InvalidToken");
            }

            return principal;
        }
        private Claim[] SetClaimsWithLog(ref AuthenticationRequest request) {
            Claim[] tempClaims = _jwtHelperService.SetClaims(ref request);
            _logger.LogDebug($"{tempClaims.Length} Claim setted");
            foreach (Claim claim in tempClaims) {
                _logger.LogTrace($"Claim Type: {claim.Type}\nClaim ValueType: {claim.ValueType}\nClaim Issuer: {claim.Issuer}\nClaim Subject: {claim.Subject}\nClaim Value: {claim.Value}\nClaim OriginalIssuer: {claim.OriginalIssuer}");
            }
            return tempClaims;
        }
    }
}
