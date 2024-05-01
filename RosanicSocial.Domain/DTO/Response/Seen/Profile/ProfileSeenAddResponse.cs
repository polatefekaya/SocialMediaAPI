using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Seen.Profile {
    public class ProfileSeenAddResponse {
        public int UserId { get; set; }
        public int SeenUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class ProfileSeenEntityExtensions {
        public static ProfileSeenAddResponse ToAddResponse(this ProfileSeenEntity entity) {
            return new ProfileSeenAddResponse {
                UserId = entity.UserId,
                SeenUserId = entity.SeenUserId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
