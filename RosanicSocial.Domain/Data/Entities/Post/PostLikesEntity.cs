using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities.Post
{
    public class PostLikesEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
