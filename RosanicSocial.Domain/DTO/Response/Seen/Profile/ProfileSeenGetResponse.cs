using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Seen.Profile {
    public class ProfileSeenGetResponse {
        public int UserId { get; set; }
        public int SeenUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class ProfileSeenEntityExtensions {
        public static ProfileSeenGetResponse ToGetResponse(this ProfileSeenEntity entity) {
            return new ProfileSeenGetResponse {
                UserId = entity.UserId,
                SeenUserId = entity.SeenUserId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
