using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities.Email.DynamicTemplate
{
    public class DynamicTemplateVerificationEntity
    {
        public string name { get; set; }
        public string confirmationLink { get; set; }
    }
}
