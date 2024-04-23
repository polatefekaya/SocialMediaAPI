using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Permissions;
using RosanicSocial.Domain.DTO.Response.Permissions;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserPermissionDbService : IUserPermissionsDbService {
        public Task<UserPermissionAddResponse> AddUserPermission(UserPermissionAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserPermissionDeleteResponse> DeleteUserPermission(UserPermissionDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserPermissionGetResponse> GetUserPermission(UserPermissionGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserPermissionUpdateResponse> UpdateUserPermission(UserPermissionUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
