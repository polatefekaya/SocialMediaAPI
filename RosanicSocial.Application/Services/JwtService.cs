using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Response.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RosanicSocial.Application.Services {
    public class JwtService : IJwtService {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration) {
            _configuration = configuration;
        }
        private enum Expirations {
            Token = 0,
            RefreshToken = 1
        }

        private string[] _expirationDates = { "Jwt:EXP_MINUTES", "RefreshToken:EXP_MINUTES" }; 

        public AuthenticationResponse CreateJwtToken(AuthenticationRequest request) {
            DateTime tokenExpiration = SetExpiration(Expirations.Token);
            DateTime refreshTokenExpiration = SetExpiration(Expirations.RefreshToken);

            Claim[] claims = SetClaims(ref request);
            SymmetricSecurityKey securityKey = SetSecurityKey();
            SigningCredentials signingCredentials = SetSigningCredentials(ref securityKey);
            JwtSecurityToken securityToken = SetSecurityTokenGenerator(ref claims, ref tokenExpiration, ref signingCredentials);

            string token = GenerateToken(ref securityToken);
            string refreshToken = GenerateRefreshToken();

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

        private DateTime SetExpiration(Expirations exp) {
            string expConfig = _expirationDates[(int)exp];
            double EXP_MINUTES = Convert.ToDouble(_configuration[expConfig]);
            return DateTime.UtcNow.AddMinutes(EXP_MINUTES);
        }
        private Claim[] SetClaims(ref AuthenticationRequest request) {
            return [
                new Claim(JwtRegisteredClaimNames.Sub, request.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Name, request.Name),
                new Claim(ClaimTypes.NameIdentifier, request.Username),
                new Claim(ClaimTypes.Email, request.Email),
            ];
        }
        private SymmetricSecurityKey SetSecurityKey() {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            return new SymmetricSecurityKey(keyBytes);
        }
        private SigningCredentials SetSigningCredentials(ref SymmetricSecurityKey securityKey) {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
        private JwtSecurityToken SetSecurityTokenGenerator(ref Claim[] claims, ref DateTime expiration, ref SigningCredentials signingCredentials) {
            return new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
        }
        private string GenerateToken(ref JwtSecurityToken securityToken) {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(securityToken);
        }

        private ClaimsPrincipal ValidateToken(string token, ref TokenValidationParameters validationParameters, out SecurityToken securityToken) {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.ValidateToken(token, validationParameters, out securityToken);
        }

        private string GenerateRefreshToken() {
            byte[] bytes = new byte[64];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public ClaimsPrincipal? GetClaimsPrincipal(string? token) {
            TokenValidationParameters validationParameters = new TokenValidationParameters() {
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SetSecurityKey(),
                ValidateLifetime = false
            };

            ClaimsPrincipal principal = ValidateToken(token, ref validationParameters, out SecurityToken securityToken);

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
