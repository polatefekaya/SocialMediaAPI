using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.DangerZone {
    public class DangerzoneDeleteResponse {
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class UserDangerZoneEntityExtensions {
        public static DangerzoneDeleteResponse ToDeleteResponse(this UserDangerZoneEntity entity) {
            return new DangerzoneDeleteResponse {
                UserId = entity.UserId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
