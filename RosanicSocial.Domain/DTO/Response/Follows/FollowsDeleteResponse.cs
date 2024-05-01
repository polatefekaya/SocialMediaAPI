using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Follows {
    public class FollowsDeleteResponse {
        public int UserId { get; set; }
        public int FollowingId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class FollowsEntityExtensions {
        public static FollowsDeleteResponse ToDeleteResponse(this FollowsEntity entity) {
            return new FollowsDeleteResponse {
                UserId = entity.UserId,
                FollowingId = entity.FollowingId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
