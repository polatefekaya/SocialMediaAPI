using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Post
{
    public class PostDeleteResponse {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class PostEntityExtensions {
        public static PostDeleteResponse ToDeleteResponse (this PostEntity entity) {
            return new PostDeleteResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                IsDeleted = entity.IsDeleted,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
