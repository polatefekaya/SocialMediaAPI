using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Statistics.Post {
    public class PostStatisticsUpdateRequest {
        public int PostId { get; set; }
        public int? LikeCount { get; set; }
        public int? CommentCount { get; set; }
        public int? ShareCount { get; set; }
        public int? SeenCount { get; set; }

        public PostStatisticsEntity ToEntity() {
            return new PostStatisticsEntity {
                PostId = PostId,
                LikeCount = LikeCount,
                CommentCount = CommentCount,
                ShareCount = ShareCount,
                SeenCount = SeenCount
            };
        }
    }
}
