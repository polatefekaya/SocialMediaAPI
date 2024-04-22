using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities {
    public class UserDangerZoneEntity {
        public int UserId { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsPermaBanned { get; set; } = false;
        public int? BanCount { get; set; } = 0;
        public int? WarningCount { get; set; } = 0;
    }
}
