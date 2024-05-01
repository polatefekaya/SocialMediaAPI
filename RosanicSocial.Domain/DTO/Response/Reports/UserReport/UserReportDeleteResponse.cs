using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.UserReport {
    public class UserReportDeleteResponse {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class UserReportEntityExtensions {
        public static UserReportDeleteResponse ToDeleteResponse(this UserReportEntity entity) {
            return new UserReportDeleteResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
