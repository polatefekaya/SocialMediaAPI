using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.Post {
    public class PostReportDeleteResponse {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostReportEntiyExtensions {
        public static PostReportDeleteResponse ToDeleteResponse(this PostReportEntity entity) {
            return new PostReportDeleteResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                PostId = entity.PostId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
