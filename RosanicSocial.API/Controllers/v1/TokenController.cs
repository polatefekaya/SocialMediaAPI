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
        public TokenController(IJwtService jwtService, UserManager<ApplicationUser> userManager) {
            _jwtService = jwtService;
            _userManager = userManager;
        }

        /// <summary>
        /// It Generates new access token for user to authenticate. If the supplied token meets the requirements, it generates a new one. 
        /// refreshToken's expiration date must not be out of date and the supplied refreshToken is have to be equavalent to user's refreshToken in Identity Database
        /// </summary>
        /// <param name="tokenmodel">Jwt Token and Refresh Token</param>
        /// <returns>New token values</returns>
        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> GenerateNewAccessToken(TokenModel tokenmodel) {
            if (tokenmodel == null) {
                return BadRequest("Invalid Client Request");
            }
            string? jwtToken = tokenmodel.Token;
            string? refreshToken = tokenmodel.RefreshToken;

            ClaimsPrincipal? principal = _jwtService.GetClaimsPrincipal(jwtToken);
            if (principal == null) {
                return BadRequest("Invalid JWT Access Token");
            }

            string? userName = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            ApplicationUser? user = await _userManager.FindByNameAsync(userName);

            if (user is null || user.RefreshToken != tokenmodel.RefreshToken || user.RefreshTokenExpiration <= DateTime.UtcNow)
            {
                return BadRequest("Invalid RefreshToken");
            }

            AuthenticationResponse response = _jwtService.CreateJwtToken(user.ToAuthRequest());
            user.RefreshToken = response.RefreshToken;
            user.RefreshTokenExpiration = response.RefreshTokenExpiration;

            await _userManager.UpdateAsync(user);

            return Ok(response);
        }
    }
}
