using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using RosanicSocial.Domain.Data.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RosanicSocial.Application.Filters {
    public class NotAutherizedUserActionFilter : IAsyncActionFilter {
        private readonly ILogger<NotAutherizedUserActionFilter> _logger;

        public NotAutherizedUserActionFilter(ILogger<NotAutherizedUserActionFilter> logger) {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {


            bool isAutherized = await IsAuthorizedUserAsync(context);

            if(!isAutherized) {
                context.Result = new ContentResult { Content = "Authorization Process Failing, Access Terminated" };
                return;
            }

            //before
            await next();
            //after
        }

        private async Task<bool> IsAuthorizedUserAsync(ActionExecutingContext context) {
            //Get the current user and compare with requested one
            string? currentUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId is null) {
                _logger.LogError("Not Signed In");
                return false;
            }

            if (!context.ActionArguments.ContainsKey("request")) {
                _logger.LogError("No request Key in Action Arguments");
                return false;
            }

            var personReq = context.ActionArguments["request"];

            string? requestedUserId = Convert.ToString(personReq?.GetType().GetProperty("UserId")?.GetValue(personReq));

            if (requestedUserId is null) {
                _logger.LogError("UserId is not supplied");
                return false;
            }

            bool isMatching = requestedUserId.Equals(currentUserId);

            if (!isMatching) {
                _logger.LogError("Requesting for different user. Access terminated");
                return false;
            }

            _logger.LogInformation("User Making Request for Same Logged In User. Access Approved");
            return true;
        }
    }
}
