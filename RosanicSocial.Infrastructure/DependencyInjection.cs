using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Application.Interfaces.Repository.Post;
using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Infrastructure.DatabaseContext;
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

            services.AddScoped<IUserBlockRepository, UserBlockRepository>();
            

            return services;
        }
    }
}
