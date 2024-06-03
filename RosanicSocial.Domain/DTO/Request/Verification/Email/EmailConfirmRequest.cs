using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Verification.Email {
    public class EmailConfirmRequest {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
