using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Statistics.Post {
    public class PostStatisticsDeleteResponse {
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostStatisticsEntityExtensions {
        public static PostStatisticsDeleteResponse ToDeleteResponse(this PostStatisticsEntity entity) {
            return new PostStatisticsDeleteResponse {
                PostId = entity.PostId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
