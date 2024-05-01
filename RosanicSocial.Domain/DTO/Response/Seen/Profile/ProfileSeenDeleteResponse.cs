using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Seen.Profile {
    public class ProfileSeenDeleteResponse {
        public int UserId { get; set; }
        public int SeenUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class ProfileSeenEntityExtensions {
        public static ProfileSeenDeleteResponse ToDeleteResponse(this ProfileSeenEntity entity) {
            return new ProfileSeenDeleteResponse {
                UserId = entity.UserId,
                SeenUserId = entity.SeenUserId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
