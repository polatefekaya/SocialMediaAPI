using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserDangerRepository : IUserDangerZoneRepository {
        public Task<UserDangerZoneEntity> AddDangerzone(UserDangerZoneEntity entity) {
            throw new NotImplementedException();
        }

        public Task<UserDangerZoneEntity> DeleteDangerzone(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserDangerZoneEntity> GetDangerzone(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserDangerZoneEntity> UpdateDangerzone(UserDangerZoneEntity entity) {
            throw new NotImplementedException();
        }
    }
}
