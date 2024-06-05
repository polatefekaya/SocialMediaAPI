using RosanicSocial.Domain.Data.Entities.Email;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Email {
    public class EmailSendTwoFactorRequest {
        public int UserId { get; set; }
        public string OTPToken { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public EmailEntity ToEntity() {
            return new EmailEntity {
                From = From,
                To = To
            };
        }
    }
}
