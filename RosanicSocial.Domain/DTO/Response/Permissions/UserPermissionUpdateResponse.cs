using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Permissions {
    public class UserPermissionUpdateResponse {
        public int UserId { get; set; }
        public bool IsLastSeenActive { get; set; } = true;
        public bool IsActiviyVisible { get; set; } = true;
        public bool IsProfileSeenHistoryActive { get; set; } = true;
        public bool IsPersonalizedAdsActive { get; set; } = true;
        public bool IsRedirectMessagesSentFromStrangersActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class UserPermissionEntityExtensions {
        public static UserPermissionUpdateResponse ToUpdateResponse(this UserPermissionEntity entity) {
            return new UserPermissionUpdateResponse {
                UserId = entity.UserId,
                IsLastSeenActive = entity.IsLastSeenActive,
                IsActiviyVisible = entity.IsActiviyVisible,
                IsProfileSeenHistoryActive = entity.IsProfileSeenHistoryActive,
                IsPersonalizedAdsActive = entity.IsPersonalizedAdsActive,
                IsRedirectMessagesSentFromStrangersActive = entity.IsRedirectMessagesSentFromStrangersActive,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
