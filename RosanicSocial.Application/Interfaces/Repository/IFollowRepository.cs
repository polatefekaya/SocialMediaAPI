using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface IFollowRepository {
        Task<FollowsEntity> AddFollows(FollowsEntity entity);
        Task<FollowsEntity> GetFollows(int id);
        Task<IQueryable<FollowsEntity>> GetAllFollows(int id);
        Task<FollowsEntity> UpdateFollows(FollowsEntity entity);
        Task<FollowsEntity> DeleteFollows(int id);
    }
}
