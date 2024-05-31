using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Response.Follows;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RosanicSocial.Application.Filters {
    public class AccountUserRelationsActionFilter : IAsyncActionFilter {
        private readonly IUserInfoDbService _userInfoDbService;
        private readonly IFollowDbService _followDbService;
        private readonly ILogger<AccountUserRelationsActionFilter> _logger;

        public AccountUserRelationsActionFilter(IUserInfoDbService userInfoDbService, ILogger<AccountUserRelationsActionFilter> logger, IFollowDbService followDbService) {
            _userInfoDbService = userInfoDbService;
            _logger = logger;
            _followDbService = followDbService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {

            //Get requestedUser
            //Check if requested users account is private or not
            //Get logged in user
            //If it's private, check if it's a friend
            bool isVisible = await CheckVisibility(context);

            if (!isVisible) {
                context.Result = new ContentResult { Content = "Account is not visible to the person who logged in" };
                return;
            }
            //before
            await next();
            //after

        }

        private async Task<bool> CheckVisibility(ActionExecutingContext context) {
            if (!context.ActionArguments.ContainsKey("request")) {
                _logger.LogError("No postRequest Key in Action Arguments");
                return false;
            }

            var personReq = context.ActionArguments["request"];

            int requestedUserId = Convert.ToInt32(personReq?.GetType().GetProperty("UserId")?.GetValue(personReq));

            BaseInfoGetResponse? response = await _userInfoDbService.GetBaseInfo(
                new BaseInfoGetRequest { 
                    UserId = requestedUserId 
                });

            if (response is null) {
                _logger.LogError("Requested User Has No Info");
                return false;
            }

            bool isSameUser = await CheckIsSameId(context, requestedUserId);

            if (isSameUser) {
                goto SAMEUSER;
            }

            bool isPrivate = response.IsPrivate;

            if (isPrivate) {
                _logger.LogInformation("Requested Account is Private, Looking For Friend Relation");
                return await CheckIsFriend(context, requestedUserId);    
            }

            SAMEUSER:

            _logger.LogDebug("There is No Visibility Problem here");
            return true;
        }

        private async Task<bool> CheckIsFriend(ActionExecutingContext context, int requestedUserId) {
            int? currentUserId = await GetCurrentUserId(context);
            if (currentUserId is null) {
                _logger.LogError("Current User Id is null");
                return false;
            }

            FollowsGetResponse? response = await _followDbService.GetFollow(
                new FollowsGetIsFollowingRequest {
                    UserId = currentUserId.Value, 
                    FollowerId = requestedUserId
                });

            if ( response is null ) {
                _logger.LogError("RequestedUser Is Not a Friend");
                return false;
            }

            _logger.LogDebug("RequestedUser is Friend, Access Approved");
            return true;
        }

        private async Task<bool> CheckIsSameId(ActionExecutingContext context, int requesteduserId) {
            int? currentUserId = await GetCurrentUserId(context);
            if (currentUserId is null) {
                _logger.LogError("Current User Id is null");
                return false;
            }

            bool isRequestedUserAndCurrentUserSame = currentUserId.Equals(requesteduserId);

            if (!isRequestedUserAndCurrentUserSame) {
                _logger.LogError("RequestedUser Is Not CurrentUser");
                return false;
            }

            _logger.LogDebug("RequestedUser is CurrentUser, Access Approved");
            return true;
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
