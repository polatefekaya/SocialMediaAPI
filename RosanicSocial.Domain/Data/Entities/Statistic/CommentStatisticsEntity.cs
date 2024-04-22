using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities.Statistic
{
    public class CommentStatisticsEntity
    {
        public int CommentId { get; set; }
        public int? ReplyCount { get; set; }
        public int? LikeCount { get; set; }
    }
}
