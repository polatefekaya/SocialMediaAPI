﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Infrastructure.Repository;

namespace RosanicSocial.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services.AddScoped<IRoseRepository, RoseRepository>();
            return services;
        }
    }
}
