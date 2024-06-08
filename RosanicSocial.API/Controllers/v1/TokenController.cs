using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Domain.DTO.Response.Authentication;
using RosanicSocial.Domain.Models;
using RosanicSocial.WebAPI.Controllers;
using System.Security.Claims;

namespace RosanicSocial.API.Controllers.v1 {

    [ApiVersion("1.0")]
    public class TokenController : CustomControllerBase {
        private readonly IJwtService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<TokenController> _logger;
        public TokenController(IJwtService jwtService, UserManager<ApplicationUser> userManager, ILogger<TokenController> logger) {
            _jwtService = jwtService;
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// It Generates new access token for user to authenticate. If the supplied token meets the requirements, it generates a new one. 
        /// refreshToken's expiration date must not be out of date and the supplied refreshToken is have to be equavalent to user's refreshToken in Identity Database
        /// </summary>
        /// <param name="tokenmodel">Jwt Token and Refresh Token</param>
        /// <returns>New token values</returns>
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> GenerateNewAccessToken(TokenModel tokenmodel) {
            AuthenticationResponse? response = await _jwtService.GenerateNewAccessToken(tokenmodel);
            if (response is null) {
                return BadRequest("Invalid RefreshToken");
            }
            return Ok(response);
        }
    }
}
