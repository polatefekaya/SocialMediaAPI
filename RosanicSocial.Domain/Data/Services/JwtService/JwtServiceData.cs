using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Services.JwtService {
    public class JwtServiceData {
        public enum Expirations {
            Token = 0,
            RefreshToken = 1
        }

        public string[] _expirationDates = { "Jwt:EXP_MINUTES", "RefreshToken:EXP_MINUTES" };
    }
}
