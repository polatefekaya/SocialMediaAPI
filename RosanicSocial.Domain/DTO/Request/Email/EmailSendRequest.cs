using RosanicSocial.Domain.Data.Entities.Email;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Email
{
    public class EmailSendRequest {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }

        public EmailEntity ToEntity() {
            return new EmailEntity { 
                From = From,
                To = To,
                Subject = Subject,
                PlainTextContent = PlainTextContent,
                HtmlContent = HtmlContent
            };
        }
    }
}
