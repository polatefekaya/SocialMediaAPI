using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Info.Detailed {
    public class DetailedInfoUpdateRequest {
        public int UserId { get; set; }
        public string? Biography { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
    }
}
