using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserPermissionsRepository : IUserPermissionsRepository {
        public Task<UserPermissionEntity> AddUserPermission(UserPermissionEntity entity) {
            throw new NotImplementedException();
        }

        public Task<UserPermissionEntity> DeleteUserPermission(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserPermissionEntity> GetUserPermission(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserPermissionEntity> UpdateUserPermission(UserPermissionEntity entity) {
            throw new NotImplementedException();
        }
    }
}
