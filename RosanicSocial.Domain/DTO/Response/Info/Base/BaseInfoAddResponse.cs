using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Info.Base {
    public class BaseInfoAddResponse {
        public int UserId { get; set; }
        public int PostCount { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public bool IsPrivate { get; set; } = false;
        public DateTime? Birthday { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class BaseInfoEntityExtensions {
        public static BaseInfoAddResponse ToAddResponse(this BaseInfoEntity entity) {
            return new BaseInfoAddResponse {
                UserId = entity.UserId,
                PostCount = entity.PostCount,
                FollowerCount = entity.FollowerCount,
                FollowingCount = entity.FollowingCount,
                IsPrivate = entity.IsPrivate,
                Birthday = entity.Birthday,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
