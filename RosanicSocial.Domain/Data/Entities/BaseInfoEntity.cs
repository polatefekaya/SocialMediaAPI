using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities {
    public class BaseInfoEntity {
        [Key]
        public int UserId { get; set; }
        public int PostCount { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
