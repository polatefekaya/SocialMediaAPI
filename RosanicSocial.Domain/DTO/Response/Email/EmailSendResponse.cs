using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Net;

namespace RosanicSocial.Domain.DTO.Response.Email {
    public class EmailSendResponse {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
        public HttpContent Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool Sent { get; set; }
    }

    public static partial class  EmailEntityExtensions {
        public static EmailSendResponse ToSendResponse(this EmailEntity entity) {
            return new EmailSendResponse {
                From = entity.From,
                To = entity.To,
                HtmlContent = entity.HtmlContent,
                PlainTextContent = entity.PlainTextContent,
                Subject = entity.Subject
            };
        }
    }
}
