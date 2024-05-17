using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Filters {
    public class FeatureDisabledTemporarilyResourceFilter : IAsyncResourceFilter {
        private readonly ILogger<FeatureDisabledTemporarilyResourceFilter> _logger;
        private readonly bool _isDisabled;
        public FeatureDisabledTemporarilyResourceFilter(ILogger<FeatureDisabledTemporarilyResourceFilter> logger, bool isDisabled = true) {
            _logger = logger;
            _isDisabled = isDisabled;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next) {

            if (!_isDisabled) {
                await next();
            }

            
            _logger.LogWarning("The Endpoint that you made request is temporarily unavailable");
            context.Result = new NotFoundResult();
            
            //before like OnActionExecuting
            
            //after like OnActionExecuted
        }
    }
}
