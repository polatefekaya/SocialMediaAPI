using RosanicSocial.Application.Interfaces.Repository.Statistic;
using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class ProfileSeenRepository : IProfileSeenRepository {
        public Task<ProfileSeenEntity> AddProfileSeen(ProfileSeenEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ProfileSeenEntity>> DeleteAllProfileSeensByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ProfileSeenEntity>> GetAllProfileSeensByUserId(int userId) {
            throw new NotImplementedException();
        }
    }
}
