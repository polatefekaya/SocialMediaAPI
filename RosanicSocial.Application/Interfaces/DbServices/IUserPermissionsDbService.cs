using RosanicSocial.Domain.DTO.Request.Permissions;
using RosanicSocial.Domain.DTO.Response.Permissions;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IUserPermissionsDbService {
        Task<UserPermissionAddResponse> AddUserPermission(UserPermissionAddRequest request);
        Task<UserPermissionGetResponse> GetUserPermission(UserPermissionGetRequest request);
        Task<UserPermissionDeleteResponse> DeleteUserPermission(UserPermissionDeleteRequest request);
        Task<UserPermissionUpdateResponse> UpdateUserPermission(UserPermissionUpdateRequest request);
    }
}
