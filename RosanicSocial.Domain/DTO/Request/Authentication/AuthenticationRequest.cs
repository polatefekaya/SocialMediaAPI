using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Authentication {
    public class AuthenticationRequest {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
