using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Application.Interfaces.Repository.Post;
using RosanicSocial.Infrastructure.Repository;

namespace RosanicSocial.Infrastructure
{
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            return services;
        }
    }
}
