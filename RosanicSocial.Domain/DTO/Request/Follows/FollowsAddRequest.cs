using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Follows {
    public class FollowsAddRequest {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
    }
}
