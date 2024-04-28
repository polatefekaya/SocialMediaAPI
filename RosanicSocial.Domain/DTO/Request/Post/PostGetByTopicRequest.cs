using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post {
    public class PostGetByTopicRequest {
        public int UserId { get; set; }
        public int Category { get; set; }
        public int Topic { get; set; }
        public int Type { get; set; }
    }
}
