using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post {
    public class PostDeleteBatchRequest {
        public int[]? PostIds { get; set; }
    }
}
