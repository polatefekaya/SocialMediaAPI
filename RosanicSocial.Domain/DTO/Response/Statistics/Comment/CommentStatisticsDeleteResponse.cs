using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Statistics.Comment {
    public class CommentStatisticsDeleteResponse {
        public int CommentId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class CommentStatisticsEntityExtensions {
        public static CommentStatisticsDeleteResponse ToDeleteResponse(this CommentStatisticsEntity entity) {
            return new CommentStatisticsDeleteResponse {
                CommentId = entity.CommentId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
