using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Identity {
    public class ApplicationUser : IdentityUser<int> {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
    }
}
