using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Statistics.Post {
    public class PostStatisticsUpdateResponse {
        public int PostId { get; set; }
        public int? LikeCount { get; set; }
        public int? CommentCount { get; set; }
        public int? ShareCount { get; set; }
        public int? SeenCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class PostStatisticsEntityExtensions {
        public static PostStatisticsUpdateResponse ToUpdateResponse(this PostStatisticsEntity entity) {
            return new PostStatisticsUpdateResponse {
                PostId = entity.PostId,
                LikeCount = entity.LikeCount,
                CommentCount = entity.CommentCount,
                ShareCount = entity.ShareCount,
                SeenCount = entity.SeenCount,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
