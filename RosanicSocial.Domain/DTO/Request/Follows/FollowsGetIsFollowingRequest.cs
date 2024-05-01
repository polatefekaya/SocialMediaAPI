using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Follows {
    public class FollowsGetIsFollowingRequest {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
    } 
}
