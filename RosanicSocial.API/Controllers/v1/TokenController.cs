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
            _logger.LogInformation("GenerateNewAccessToken Controller is started");

            if (tokenmodel == null) {
                _logger.LogError("Invalid Client Request");
                return BadRequest("Invalid Client Request");
            }

            string? jwtToken = tokenmodel.Token;
            string? refreshToken = tokenmodel.RefreshToken;

            ClaimsPrincipal? principal = _jwtService.GetClaimsPrincipal(jwtToken);
            _logger.LogDebug("ClaimsPrincipal is setted");

            if (principal == null) {
                _logger.LogError($"Invalid JWT Access Token");
                return BadRequest("Invalid JWT Access Token");
            }

            string? userName = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userName == null) {
                _logger.LogError("No UserName Found");
                return BadRequest("No UserName Found");
            }
            _logger.LogTrace($"UserName is extracted from ClaimPrinciples: {userName}");

            ApplicationUser? user = await _userManager.FindByNameAsync(userName);
            _logger.LogDebug("ApplicationUser is setted via UserManager");

            bool isUserNull = user is null;
            bool isRefreshTokensNotMatch = user.RefreshToken != tokenmodel.RefreshToken;
            bool isRefreshTokenExpired = user.RefreshTokenExpiration <= DateTime.UtcNow;

            if (isUserNull || isRefreshTokensNotMatch || isRefreshTokenExpired)
            {
                _logger.LogTrace($"Some error about RefreshToken\nIs User Null: {isUserNull}\nIs Refresh Tokens Not Matching: {isRefreshTokensNotMatch}\nIs Refresh Token Expired: {isRefreshTokenExpired}");
                
                _logger.LogError("Invalid RefreshToken");
                return BadRequest("Invalid RefreshToken");
            }

            AuthenticationResponse response = _jwtService.CreateJwtToken(user.ToAuthRequest());
            _logger.LogDebug("AuthenticationResponse is created");

            user.RefreshToken = response.RefreshToken;
            user.RefreshTokenExpiration = response.RefreshTokenExpiration;

            _logger.LogTrace($"User RefreshToken: {response.RefreshToken}\nUser RefreshToken Expiration: {response.RefreshTokenExpiration}");

            await _userManager.UpdateAsync(user);
            _logger.LogDebug("User Manager updated the database with new data");

            return Ok(response);
        }
    }
}
