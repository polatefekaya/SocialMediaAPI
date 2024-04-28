using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace RosanicSocial.Domain.DTO.Request.Info.Detailed {
    public class DetailedInfoDeleteRequest {
        public int UserId { get; set; }
    }
}
