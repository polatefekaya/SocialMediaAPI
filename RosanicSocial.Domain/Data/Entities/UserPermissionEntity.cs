using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities {
    public class UserPermissionEntity {
        [Key]
        public int UserId { get; set; }

        public bool IsLastSeenActive { get; set; } = true;
        public bool IsActiviyVisible { get; set; } = true;
        public bool IsProfileSeenHistoryActive { get; set; } = true;
        public bool IsPersonalizedAdsActive { get; set; } = true;
        public bool IsRedirectMessagesSentFromStrangersActive { get; set; } = true;
    }
}
