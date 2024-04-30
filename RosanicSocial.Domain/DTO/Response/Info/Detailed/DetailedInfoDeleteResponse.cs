using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Info.Detailed {
    public class DetailedInfoDeleteResponse {
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class DetailedInfoEntityExtesions {
        public static DetailedInfoDeleteResponse ToDeleteResponse(this DetailedInfoEntity entity) {
            return new DetailedInfoDeleteResponse {
                UserId = entity.UserId,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}

