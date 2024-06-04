using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities.Email {
    public class DynamicTemplateVerificationEntity {
        public string name { get; set; }
        public string confirmationLink { get; set; }
    }
}
