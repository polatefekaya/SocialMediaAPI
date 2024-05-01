using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Statistics.Comment {
    public class CommentStatisticsUpdateResponse {
        public int CommentId { get; set; }
        public int? ReplyCount { get; set; }
        public int? LikeCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class CommentStatisticsEntityExtensions {
        public static CommentStatisticsUpdateResponse ToUpdateResponse(this CommentStatisticsEntity entity) {
            return new CommentStatisticsUpdateResponse {
                CommentId = entity.CommentId,
                ReplyCount = entity.ReplyCount,
                LikeCount = entity.LikeCount,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
