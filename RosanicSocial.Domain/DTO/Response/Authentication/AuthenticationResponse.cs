using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Authentication {
    public class AuthenticationResponse {
        public string? Name { get; set; } = string.Empty;
        public string? Username { get; set;} = string.Empty;
        public string? Email {  get; set; } = string.Empty;
        public string? Token {  get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string? RefreshToken {  get; set; } = string.Empty;
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
