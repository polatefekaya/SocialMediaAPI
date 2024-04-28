using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post {
    public class PostGetByCategoryRequest {
        public int UserId { get; set; }
        public int Category { get; set; }
    }
}
