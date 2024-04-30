using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Info.Base {
    public class BaseInfoGetResponse {
        public int UserId { get; set; }
        public int PostCount { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class BaseInfoEntityExtensions {
        public static BaseInfoGetResponse ToGetResponse (this BaseInfoEntity entity) {
            return new BaseInfoGetResponse {
                UserId = entity.UserId,
                PostCount = entity.PostCount,
                FollowerCount = entity.FollowerCount,
                FollowingCount = entity.FollowingCount,
                IsPrivate = entity.IsPrivate,
                Birthday = entity.Birthday,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
