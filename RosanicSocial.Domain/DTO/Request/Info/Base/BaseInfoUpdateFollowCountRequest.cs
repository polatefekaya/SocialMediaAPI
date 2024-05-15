using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Info.Base {
    public class BaseInfoUpdateFollowCountRequest {
        public int UserId { get; set; }
        public int Change { get; set; }
    }
}
