using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace RosanicSocial.Domain.DTO.Request.Info.Detailed {
    public class DetailedInfoGetRequest {
        public int UserId { get; set; }
        public DetailedInfoEntity ToEntity() {
            return new DetailedInfoEntity {
                UserId = UserId
            };
        }
    }
}
