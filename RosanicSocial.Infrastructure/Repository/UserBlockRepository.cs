using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserBlockRepository : IUserBlockRepository {
        public Task<UserBlockEntity> AddBlock(UserBlockEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserBlockEntity>> DeleteAllBlocks(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserBlockEntity> DeleteBlock(int userId, int blockedId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserBlockEntity>> GetAllBlocksByUserId(int userId) {
            throw new NotImplementedException();
        }
    }
}
