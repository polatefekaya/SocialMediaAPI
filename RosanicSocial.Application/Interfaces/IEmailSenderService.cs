using RosanicSocial.Domain.DTO.Request.Email;
using RosanicSocial.Domain.DTO.Response.Email;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces {
    public interface IEmailSenderService {
        Task<EmailSendResponse?> SendEmail(EmailSendRequest request);
    }
}
