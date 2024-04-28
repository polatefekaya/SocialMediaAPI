using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Permissions {
    public class UserPermissionUpdateRequest {
        public int UserId { get; set; }
        public bool IsLastSeenActive { get; set; }
        public bool IsActiviyVisible { get; set; }
        public bool IsProfileSeenHistoryActive { get; set; }
        public bool IsPersonalizedAdsActive { get; set; }
        public bool IsRedirectMessagesSentFromStrangersActive { get; set; }
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
