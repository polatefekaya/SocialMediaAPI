using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Follows {
    public class FollowsAddRequest {
        public int UserId { get; set; }
        public int FollowingId { get; set; }
        public FollowsEntity ToEntity() {
            return new FollowsEntity {
                UserId = UserId,
                FollowingId = FollowingId
            };
        }
    }
}
