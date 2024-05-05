using RosanicSocial.Domain.DTO.Request.Authentication;
using RosanicSocial.Domain.DTO.Response.Authentication;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces {
    public interface IJwtService {
        AuthenticationResponse CreateJwtToken(AuthenticationRequest request);
    }
}
