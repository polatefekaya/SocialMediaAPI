using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.Comment {
    public class CommentReportDeleteResponse {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class CommentReportEntityExtensions {
        public static CommentReportDeleteResponse ToDeleteResponse(this CommentReportEntity entity) {
            return new CommentReportDeleteResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                CommentId = entity.CommentId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
