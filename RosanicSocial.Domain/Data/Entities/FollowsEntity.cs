using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities {
    public class FollowsEntity {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FollowingId { get; set;}
        public DateTime? CreatedAt { get; set;}
    }
}
