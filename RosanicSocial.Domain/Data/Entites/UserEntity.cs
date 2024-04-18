using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities {
    public class UserEntity {
        [Key]
        public int UserId { get; set; }
        public string? Biography { get; set; }
        public string? Country {  get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedAt { get; set;}
        public DateTime? UpdatedAt { get; set;}
    }
}
