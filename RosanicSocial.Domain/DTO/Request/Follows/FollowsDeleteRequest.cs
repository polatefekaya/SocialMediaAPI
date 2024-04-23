using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Follows {
    public class FollowsDeleteRequest {
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
    }
}
