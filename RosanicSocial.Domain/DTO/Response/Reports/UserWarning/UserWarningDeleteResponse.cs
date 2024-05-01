using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.UserWarning {
    public class UserWarningDeleteResponse {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class UserWarningEntityExtensions {
        public static UserWarningDeleteResponse ToDeleteResponse(this UserWarningEntity entity) {
            return new UserWarningDeleteResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
