using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Statistic {
    public interface IPostSeenRepository {
        Task<PostSeenEntity> AddPostSeen(PostSeenEntity entity);
        Task<IQueryable<PostSeenEntity>> GetPostSeensByPostId(int postId);
        Task<IQueryable<PostSeenEntity>> GetPostSeensByUserId(int userId);
        Task<IQueryable<PostSeenEntity>> DeletePostSeensByUserId(int userId);
        Task<IQueryable<PostSeenEntity>> DeletePostSeensByPostId(int postId);
    }
}
