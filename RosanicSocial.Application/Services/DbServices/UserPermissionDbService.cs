using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.DTO.Request.Permissions;
using RosanicSocial.Domain.DTO.Response.Permissions;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserPermissionDbService : IUserPermissionsDbService {
        private readonly IUserPermissionsRepository _repo;
        public UserPermissionDbService(IUserPermissionsRepository repository) {
            _repo = repository;
        }
        public Task<UserPermissionAddResponse> AddUserPermission(UserPermissionAddRequest request) {
            throw new NotImplementedException();
        }

        public async Task<UserPermissionDeleteResponse> DeleteUserPermission(UserPermissionDeleteRequest request) {
            UserPermissionEntity et = await _repo.DeleteUserPermission(request.UserId);

            return null;
        }

        public Task<UserPermissionGetResponse> GetUserPermission(UserPermissionGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<UserPermissionUpdateResponse> UpdateUserPermission(UserPermissionUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
