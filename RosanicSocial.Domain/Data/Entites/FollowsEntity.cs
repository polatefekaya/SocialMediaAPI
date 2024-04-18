using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities {
    public class FollowsEntity {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int FollowerId { get; set; }
        [Required]
        public int FollowingId { get; set;}
        public DateTime? CreatedAt { get; set;}
    }
}
