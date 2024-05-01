using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.UserWarning {
    public class UserWarningGetResponse {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int WarningCategory { get; set; }
        public int WarningLevel { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class UserWarningEntityExtensions {
        public static UserWarningGetResponse ToGetResponse(this UserWarningEntity entity) {
            return new UserWarningGetResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                WarningCategory = entity.WarningCategory,
                WarningLevel = entity.WarningLevel,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
