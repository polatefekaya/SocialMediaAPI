using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Email {
    public class EmailSendResetPasswordRequest {
        public string From { get; set; }
        public string To { get; set; }
        public string ConfirmationLink { get; set; }
    }
}
