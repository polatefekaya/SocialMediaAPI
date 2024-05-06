using Microsoft.AspNetCore.Identity;
using RosanicSocial.Domain.DTO.Request.Authentication;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Identity {
    public class ApplicationUser : IdentityUser<int> {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
    public static class ApplicationUserExtensions {
        public static AuthenticationRequest ToAuthRequest(this ApplicationUser user) {
            return new AuthenticationRequest {
                Id = user.Id.ToString(),
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Username = user.UserName
            };
        }
    }
}
