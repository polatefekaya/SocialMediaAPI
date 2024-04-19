using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace RosanicSocial.Application {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            return services;
        }
    }
}
