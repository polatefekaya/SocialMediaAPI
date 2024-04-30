using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Info.Base {
    public class BaseInfoDeleteResponse {
        public int UserId { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class BaseInfoEntityExtensions {
        public static BaseInfoDeleteResponse ToDeleteResponse (this BaseInfoEntity entity) {
            return new BaseInfoDeleteResponse {
                UserId = entity.UserId,
                IsPrivate = entity.IsPrivate,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
