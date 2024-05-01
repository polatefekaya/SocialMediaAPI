using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RosanicSocial.Domain.DTO.Response.Follows {
    public class FollowsAddResponse {
        public int UserId { get; set; }
        public int FollowingId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class FollowsEntityExtensions {
        public static FollowsAddResponse ToAddResponse(this FollowsEntity entity) {
            return new FollowsAddResponse {
                UserId = entity.UserId,
                FollowingId = entity.FollowingId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
