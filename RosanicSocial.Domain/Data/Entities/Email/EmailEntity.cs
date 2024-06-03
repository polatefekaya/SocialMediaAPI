using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities.Email
{
    public class EmailEntity
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}
