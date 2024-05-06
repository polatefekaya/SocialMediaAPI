using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Models {
    public class TokenModel {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
