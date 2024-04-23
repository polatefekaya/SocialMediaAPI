using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface IUserPermissionRepository {
        Task<UserPermissionEntity> AddUserPermission(UserPermissionEntity entity);
        Task<UserPermissionEntity> UpdateUserPermission(UserPermissionEntity entity);
        Task<UserPermissionEntity> DeleteUserPermission(int userId);
        Task<UserPermissionEntity> GetUserPermission(int userId);
    }
}
