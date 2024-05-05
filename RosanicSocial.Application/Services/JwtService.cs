using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Response.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RosanicSocial.Application.Services {
    public class JwtService : IJwtService {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public AuthenticationResponse CreateJwtToken(AuthenticationRequest request) {
            DateTime expiration = SetExpiration();
            Claim[] claims = SetClaims(ref request);
            SymmetricSecurityKey securityKey = SetSecurityKey();
            SigningCredentials signingCredentials = SetSigningCredentials(ref securityKey);
            JwtSecurityToken securityToken = SetSecurityTokenGenerator(ref claims, ref expiration, ref signingCredentials);

            string token = GenerateToken(ref securityToken);

            return new AuthenticationResponse {
                Username = request.Username,
                Email = request.Email,
                Expiration = expiration,
                Name = request.Name,
                Token = token
            };
        }

        private DateTime SetExpiration() {
            double EXP_MINUTES = Convert.ToDouble(_configuration["Jwt:EXP_MINUTES"]);
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
    }
}
