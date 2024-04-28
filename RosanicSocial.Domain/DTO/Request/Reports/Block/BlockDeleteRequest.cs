using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.Block {
    public class BlockDeleteRequest {
        public int UserId { get; set; }
        public int BlockedUserId { get; set; }
    }
}
