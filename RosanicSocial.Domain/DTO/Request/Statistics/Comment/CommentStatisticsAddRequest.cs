using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Statistics.Comment {
    public class CommentStatisticsAddRequest {
        public int CommentId { get; set; }
        public int? ReplyCount { get; set; }
        public int? LikeCount { get; set; }
        
        public CommentStatisticsEntity ToEntity() {
            return new CommentStatisticsEntity {
                CommentId = CommentId,
                ReplyCount = ReplyCount,
                LikeCount = LikeCount
            };
        }
    }
}
