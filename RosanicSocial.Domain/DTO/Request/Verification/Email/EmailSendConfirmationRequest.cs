using RosanicSocial.Domain.Data.Identity;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Verification.Email {
    public class EmailSendConfirmationRequest {
        public string Email { get; set; }
        public ApplicationUser User { get; set; }
    }
}
