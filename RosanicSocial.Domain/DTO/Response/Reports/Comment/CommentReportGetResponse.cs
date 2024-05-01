using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.Comment {
    public class CommentReportGetResponse {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string? Reason { get; set; }
        public int ReportType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class CommentReportEntityExtensions {
        public static CommentReportGetResponse ToGetResponse(this CommentReportEntity entity) {
            return new CommentReportGetResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                CommentId = entity.CommentId,
                Reason = entity.Reason,
                ReportType = entity.ReportType,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
