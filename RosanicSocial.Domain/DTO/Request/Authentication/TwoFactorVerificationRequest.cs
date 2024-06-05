using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Authentication {
    public class TwoFactorVerificationRequest {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
