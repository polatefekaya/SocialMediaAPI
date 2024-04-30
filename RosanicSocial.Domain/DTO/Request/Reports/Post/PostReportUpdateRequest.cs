using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.Post {
    public class PostReportUpdateRequest {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? Reason { get; set; }
        public int ReportType { get; set; }

        public PostReportEntity ToEntity() {
            return new PostReportEntity {
                Id = Id,
                UserId = UserId,
                PostId = PostId,
                Reason = Reason,
                ReportType = ReportType
            };
        }
    }
}
