using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.Background {
    public class RefreshTokenCheckerService : BackgroundService {
        private readonly ILogger<RefreshTokenCheckerService> _logger;
        private readonly IJwtService _jwtService;
        public RefreshTokenCheckerService(ILogger<RefreshTokenCheckerService> logger, IJwtService jwtService) {
            _logger = logger;
            _jwtService = jwtService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            //while (!stoppingToken.IsCancellationRequested) {
            //    await _jwtService.GenerateNewAccessToken();
            //}
        }
    }
}
