using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class FollowRepository : IFollowRepository {
        public Task<FollowsEntity> AddFollows(FollowsEntity entity) {
            throw new NotImplementedException();
        }

        public Task<FollowsEntity> DeleteFollows(int id) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<FollowsEntity>> GetAllFollows(int id) {
            throw new NotImplementedException();
        }

        public Task<FollowsEntity> GetFollows(int id) {
            throw new NotImplementedException();
        }

        public Task<FollowsEntity> UpdateFollows(FollowsEntity entity) {
            throw new NotImplementedException();
        }
    }
}
