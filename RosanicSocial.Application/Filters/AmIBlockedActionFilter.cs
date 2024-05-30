using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Filters {
    public class AmIBlockedActionFilter : IAsyncActionFilter {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            throw new NotImplementedException();
        }
    }
}
