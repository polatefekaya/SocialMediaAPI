using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Follows {
    public class FollowsGetIsFollowingRequest {
        public int FollowingId { get; set; }
        public int FollowerId { get; set; }
        public FollowsEntity ToEntity() {
            return new FollowsEntity {
                FollowerId = FollowerId,
                FollowingId = FollowingId
            };
        }
    } 
}
