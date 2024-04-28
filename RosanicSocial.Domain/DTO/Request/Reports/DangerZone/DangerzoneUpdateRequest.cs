using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.DangerZone {
    public class DangerzoneUpdateRequest {
        public int UserId { get; set; }
        public bool IsBanned { get; set; }
        public bool IsPermaBanned { get; set; }
        public int? BanCount { get; set; }
        public int? WarningCount { get; set; }

        public UserDangerZoneEntity ToEntity() {
            return new UserDangerZoneEntity {
                UserId = UserId,
                IsBanned = IsBanned,
                IsPermaBanned = IsPermaBanned,
                BanCount = BanCount,
                WarningCount = WarningCount
            };
        }
    }
}
