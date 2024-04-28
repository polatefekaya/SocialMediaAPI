using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Permissions {
    public class UserPermissionAddRequest {
        public int UserId { get; set; }
        public bool IsLastSeenActive { get; set; } = true;
        public bool IsActiviyVisible { get; set; } = true;
        public bool IsProfileSeenHistoryActive { get; set; } = true;
        public bool IsPersonalizedAdsActive { get; set; } = true;
        public bool IsRedirectMessagesSentFromStrangersActive { get; set; } = true;

        public UserPermissionEntity ToEntity() {
            return new UserPermissionEntity {
                UserId = UserId,
                IsLastSeenActive = IsLastSeenActive,
                IsActiviyVisible = IsActiviyVisible,
                IsProfileSeenHistoryActive = IsProfileSeenHistoryActive,
                IsPersonalizedAdsActive = IsPersonalizedAdsActive,
                IsRedirectMessagesSentFromStrangersActive = IsRedirectMessagesSentFromStrangersActive
            };
        }
    }
}
