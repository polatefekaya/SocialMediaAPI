using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.Comment {
    public class CommentReportAddRequest {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string? Reason { get; set; }
        public int ReportType { get; set; }

        public CommentReportEntity ToEntity() {
            return new CommentReportEntity {
                UserId = UserId,
                CommentId = CommentId,
                Reason = Reason,
                ReportType = ReportType
            };
        }
    }
}
