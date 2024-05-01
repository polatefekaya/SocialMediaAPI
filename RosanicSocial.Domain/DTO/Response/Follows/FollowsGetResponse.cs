using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Follows {
    public class FollowsGetResponse {
        public int UserId { get; set; }
        public int FollowingId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class FollowsEntityExtensions {
        public static FollowsGetResponse ToGetResponse(this FollowsEntity entity) {
            return new FollowsGetResponse {
                UserId = entity.UserId,
                FollowingId = entity.FollowingId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
