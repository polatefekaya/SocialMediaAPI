using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post
{
    public class PostDeleteRequest{
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
