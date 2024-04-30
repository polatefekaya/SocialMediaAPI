using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Permissions {
    public class UserPermissionDeleteResponse {
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class UserPermissionEntityExtensions {
        public static UserPermissionDeleteResponse ToDeleteResponse(this UserPermissionEntity entity) {
            return new UserPermissionDeleteResponse {
                UserId = entity.UserId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
