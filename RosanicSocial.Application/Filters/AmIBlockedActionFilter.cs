using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RosanicSocial.Application.Filters {
    public class AmIBlockedActionFilter : IAsyncActionFilter {
        private readonly IUserBlockDbService _userBlockDbService;
        private readonly ILogger<AmIBlockedActionFilter> _logger;

        public AmIBlockedActionFilter(IUserBlockDbService userBlockDbService, ILogger<AmIBlockedActionFilter> logger) {
            _userBlockDbService = userBlockDbService;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            //Current User Id and Controlled User 

            BlockGetRequest request = new BlockGetRequest {
                UserId = await GetCurrentUserId(context) ?? -1,
                BlockedUserId = await GetRequestedUserIdFromActionArguments(context),

            };

            BlockGetResponse? response = await _userBlockDbService.GetAmIBlocked(request);
            if (response is not null) {
                _logger.LogError($"Requested UserId:{request.BlockedUserId} is blocked the current UserId:{request.UserId}");
                context.Result = new ContentResult { Content = "Requested User is Blocked The Current User." };
            } else {
                _logger.LogError($"Requested UserId:{request.BlockedUserId} is NOT blocked the current UserId:{request.UserId}");
                await next();
            }
        }

        private async Task<int> GetRequestedUserIdFromActionArguments(ActionExecutingContext context) {
            var personReq = context.ActionArguments["request"];
            int requestedUserId = Convert.ToInt32(personReq?.GetType().GetProperty("UserId")?.GetValue(personReq));
            return requestedUserId;
        }

        private async Task<int?> GetCurrentUserId(ActionExecutingContext context) {
            string? currentUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId is null) {
                _logger.LogError("Not Signed In");
                return null;
            }

            return Convert.ToInt32(currentUserId);
        }

    }
}
