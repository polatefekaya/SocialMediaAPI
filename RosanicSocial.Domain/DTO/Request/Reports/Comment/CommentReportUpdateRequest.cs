using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.Comment {
    public class CommentReportUpdateRequest {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string? Reason { get; set; }
        public int ReportType { get; set; }

        public CommentReportEntity ToEntity() {
            return new CommentReportEntity {
                Id = Id,
                CommentId = CommentId,
                Reason = Reason,
                ReportType = ReportType
            };
        }
    }
}
