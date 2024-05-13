using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface IFollowRepository {
        Task<FollowsEntity> AddFollows(FollowsEntity entity);
        Task<FollowsEntity?> GetFollows(int userId, int followingId);
        Task<FollowsEntity[]> GetAllFollowings(int id);
        Task<FollowsEntity[]> GetAllFollowers(int id);
        Task<FollowsEntity> UpdateFollows(FollowsEntity entity);
        Task<FollowsEntity?> DeleteFollows(int userId, int followingId);
        Task<FollowsEntity[]> DeleteAllFollows(int id);
    }
}
