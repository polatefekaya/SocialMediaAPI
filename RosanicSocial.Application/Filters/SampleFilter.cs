using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Filters {
    public class SampleFilter : IActionFilter {
        private readonly ILogger<SampleFilter> _logger;
        public SampleFilter(ILogger<SampleFilter> logger) {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context) {
            _logger.LogDebug($"{nameof(OnActionExecuted)} is started");
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            _logger.LogDebug($"{nameof(OnActionExecuting)} is started");
        }
    }
}
