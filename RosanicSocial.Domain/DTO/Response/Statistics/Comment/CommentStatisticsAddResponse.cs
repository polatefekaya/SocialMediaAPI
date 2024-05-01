using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Statistics.Comment {
    public class CommentStatisticsAddResponse {
        public int CommentId { get; set; }
        public int? ReplyCount { get; set; }
        public int? LikeCount { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class CommentStatisticsEntityExtensions {
        public static CommentStatisticsAddResponse ToAddResponse(this CommentStatisticsEntity entity) {
            return new CommentStatisticsAddResponse {
                CommentId = entity.CommentId,
                ReplyCount = entity.ReplyCount,
                LikeCount = entity.LikeCount,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
