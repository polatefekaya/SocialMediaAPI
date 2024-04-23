using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities.Statistic
{
    public class PostStatisticsEntity
    {
        public int PostId { get; set; }
        public int? LikeCount { get; set; }
        public int? CommentCount { get; set; }
        public int? ShareCount { get; set; }
        public int? SeenCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
    }
}
