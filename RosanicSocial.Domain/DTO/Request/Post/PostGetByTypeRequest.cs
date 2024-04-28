using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post {
    public class PostGetByTypeRequest {
        public int UserId { get; set; }
        public int Category {  get; set; }
        public int Type {  get; set; }
    }
}
