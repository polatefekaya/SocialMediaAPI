using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Info.Base {
    public class BaseInfoAddRequest {
        public int UserId { get; set; }
        public int PostCount { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime? Birthday { get; set; }
    }
}
