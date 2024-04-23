using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Permissions {
    public class UserPermissionUpdateRequest {
        public int UserId { get; set; }
        public bool? IsLastSeenActive { get; set; }
        public bool? IsActiviyVisible { get; set; }
        public bool? IsProfileSeenHistoryActive { get; set; }
        public bool? IsPersonalizedAdsActive { get; set; }
        public bool? IsRedirectMessagesSentFromStrangersActive { get; set; }
    }
}
