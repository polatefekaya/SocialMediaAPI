using RosanicSocial.Domain.DTO.Request.Email;
using RosanicSocial.Domain.DTO.Response.Email;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces {
    public interface IEmailSenderService {
        Task<EmailSendResponse?> SendEmail(EmailSendRequest request);
        Task<EmailSendResponse?> SendVerificationEmail(EmailSendVerificationRequest request);
        Task<EmailSendResponse?> SendTwoFactorEmail(EmailSendTwoFactorRequest request);
        Task<EmailSendResponse?> SendResetPasswordEmail(EmailSendResetPasswordRequest request);
    }
}
