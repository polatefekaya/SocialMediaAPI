using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Application.Interfaces.Helpers;
using RosanicSocial.Domain.Data.Services.JwtService;
using RosanicSocial.Domain.DTO.Request.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static RosanicSocial.Domain.Data.Services.JwtService.JwtServiceData;

namespace RosanicSocial.Application.Services.Helpers {
    public class JwtHelperService : IJwtHelperService {
        private readonly IConfiguration _configuration;
        public JwtHelperService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string GenerateRefreshToken() {
            byte[] bytes = new byte[64];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public string GenerateToken(ref JwtSecurityToken securityToken) {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(securityToken);
        }

        public Claim[] SetClaims(ref AuthenticationRequest request) {
            return [
                new Claim(JwtRegisteredClaimNames.Sub, request.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Name, request.Name),
                new Claim(ClaimTypes.NameIdentifier, request.Username),
                new Claim(ClaimTypes.Email, request.Email),
            ];
        }

        public DateTime SetExpiration(JwtServiceData.Expirations expirations) {
            string jwtConfig = JwtServiceData.jwtDataDictionary[expirations];
            double EXP_MINUTES = Convert.ToDouble(_configuration[jwtConfig]);
            return DateTime.UtcNow.AddMinutes(EXP_MINUTES);
        }

        public SymmetricSecurityKey SetSecurityKey() {
            string jwtConfig = JwtServiceData.jwtDataDictionary[JwtServiceData.Expirations.Key];
            byte[] keyBytes = Encoding.UTF8.GetBytes(_configuration[jwtConfig]);
            return new SymmetricSecurityKey(keyBytes);
        }

        public JwtSecurityToken SetSecurityTokenGenerator(ref Claim[] claims, ref DateTime expiration, ref SigningCredentials signingCredentials) {
            return new JwtSecurityToken(_configuration[JwtServiceData.jwtDataDictionary[JwtServiceData.Expirations.Issuer]],
                _configuration[JwtServiceData.jwtDataDictionary[JwtServiceData.Expirations.Audience]],
                claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
        }

        public SigningCredentials SetSigningCredentials(ref SymmetricSecurityKey securityKey) {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        public ClaimsPrincipal ValidateToken(string token, ref TokenValidationParameters validationParameters, out SecurityToken securityToken) {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.ValidateToken(token, validationParameters, out securityToken);
        }
    }
}
