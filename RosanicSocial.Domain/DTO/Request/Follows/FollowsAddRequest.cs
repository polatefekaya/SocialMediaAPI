using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Follows {
    public class FollowsAddRequest {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
        public FollowsEntity ToEntity() {
            return new FollowsEntity {
                Id = Id,
                FollowerId = FollowerId,
                FollowingId = FollowingId
            };
        }
    }
}
