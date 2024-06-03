using Microsoft.Extensions.Configuration;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.Data.Entities.Email;
using RosanicSocial.Domain.DTO.Request.Email;
using RosanicSocial.Domain.DTO.Response.Email;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services
{
    public class EmailSenderService : IEmailSenderService {
        private readonly IConfiguration _configuration;

        public EmailSenderService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public async Task<EmailSendResponse?> SendEmail(EmailSendRequest request) {
            EmailEntity entity = request.ToEntity();
            string? apiKey = _configuration["ApiKey:SendGrid"];
            if (apiKey is null) {
                return null;
            }

            SendGridClient emailClient = new SendGridClient(apiKey);

            EmailAddress from = new EmailAddress(entity.From, _configuration["EmailOptions:SenderName"]);
            EmailAddress to = new EmailAddress(entity.To);

            DynamicTemplateOTPEntity otpEntity = new DynamicTemplateOTPEntity {
                otpCode = 894051
            };

            SendGridMessage msg2 = MailHelper.CreateSingleTemplateEmail(
                from: from,
                to: to,
                templateId: "d-893bcda06a8046a78f1264abaa89094b",
                dynamicTemplateData: otpEntity 
                );

            /*
            SendGridMessage msg = MailHelper.CreateSingleEmail(
                from: from,
                to: to,
                subject: entity.Subject,
                plainTextContent: entity.PlainTextContent,
                htmlContent: entity.HtmlContent
            );
            */

            SendGrid.Response? response = await emailClient.SendEmailAsync(msg2);

            EmailSendResponse emailSendResponse = entity.ToSendResponse();
            emailSendResponse.Sent = response.IsSuccessStatusCode;
            emailSendResponse.Message = response.Body;
            emailSendResponse.StatusCode = response.StatusCode;

            return emailSendResponse;
        }
    }
}
