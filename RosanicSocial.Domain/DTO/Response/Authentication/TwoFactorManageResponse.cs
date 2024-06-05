using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Authentication {
    public class TwoFactorManageResponse {
        public string Token { get; set; }
        public bool isVerified { get; set; }
        public bool isTwoFactorEnabled { get; set; }
    }
}
