using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Application.Interfaces.Helpers;
using RosanicSocial.Domain.Data.Services.JwtService;
using RosanicSocial.Domain.DTO.Request.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RosanicSocial.Application.Services.Helpers {
    public class JwtHelperService : IJwtHelperService {
        public Claim[] SetClaims(ref AuthenticationRequest request) {
            throw new NotImplementedException();
        }

        public DateTime SetExpiration(JwtServiceData.Expirations expirations) {
            throw new NotImplementedException();
        }

        public SymmetricSecurityKey SetSecurityKey() {
            throw new NotImplementedException();
        }
    }
}
