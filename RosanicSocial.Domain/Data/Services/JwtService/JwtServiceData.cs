using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Services.JwtService {
    public class JwtServiceData {
        public enum Expirations {
            Token = 0,
            RefreshToken = 1,
            Issuer = 2,
            Audience = 3,
            Key = 4
        }

        public static Dictionary<Expirations, string> jwtDataDictionary = new Dictionary<Expirations, string>() {
            {Expirations.Token, "Jwt:EXP_MINUTES" },
            {Expirations.RefreshToken, "RefreshToken:EXP_MINUTES" },
            {Expirations.Issuer, "Jwt:Issuer" },
            {Expirations.Audience, "Jwt:Audience" },
            {Expirations.Key, "Jwt:Key" }
        };
    }
}
