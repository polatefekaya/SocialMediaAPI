using Microsoft.IdentityModel.Tokens;
using RosanicSocial.Domain.Data.Services.JwtService;
using RosanicSocial.Domain.DTO.Request.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RosanicSocial.Application.Interfaces.Helpers {
    public interface IJwtHelperService {
        DateTime SetExpiration(JwtServiceData.Expirations expirations);
        Claim[] SetClaims(ref AuthenticationRequest request);
        SymmetricSecurityKey SetSecurityKey();
    }

}
