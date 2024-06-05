using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Authentication {
    public class TwoFactorVerificationResponse {
        public string Token { get; set; }
        public bool isVerified { get; set; }
    }
}
