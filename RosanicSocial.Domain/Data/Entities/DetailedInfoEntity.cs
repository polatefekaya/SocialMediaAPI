using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace RosanicSocial.Domain.Data.Entities {
    public class DetailedInfoEntity {
        [Key]
        public int UserId { get; set; }
        public string? Biography { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
    }
}
