using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.DangerZone {
    public class DangerzoneGetResponse {
        public int UserId { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsPermaBanned { get; set; } = false;
        public int? BanCount { get; set; } = 0;
        public int? WarningCount { get; set; } = 0;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class UserDangerZoneEntityExtensions {
        public static DangerzoneGetResponse ToGetResponse(this UserDangerZoneEntity entity) {
            return new DangerzoneGetResponse {
                UserId = entity.UserId,
                IsBanned = entity.IsBanned,
                IsPermaBanned = entity.IsPermaBanned,
                BanCount = entity.BanCount,
                WarningCount = entity.WarningCount,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
