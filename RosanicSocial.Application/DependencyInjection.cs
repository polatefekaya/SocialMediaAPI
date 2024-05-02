using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using RosanicSocial.Application.Interfaces.Creators;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Application.Services.Creators;
using RosanicSocial.Application.Services.DbServices;
using RosanicSocial.Application.Services.Factories;

namespace RosanicSocial.Application {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddScoped<ICommentDbService, CommentDbService>();
            services.AddScoped<IFollowDbService, FollowDbService>();
            services.AddScoped<ILikeDbService, LikeDbService>();
            services.AddScoped<IPostDbService, PostDbService>();
            services.AddScoped<IUserInfoDbService, UserInfoDbService>();
            services.AddScoped<IDbTableCreatorFactoryService, DbTableCreatorFactoryService>();
            services.AddScoped<IDbTableCreatorService, DbTableCreatorService>();

            return services;
        }
    }
}
