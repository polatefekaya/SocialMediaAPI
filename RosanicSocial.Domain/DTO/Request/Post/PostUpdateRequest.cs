using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post
{
    public class PostUpdateRequest{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; } = 0;
        public int? Type { get; set; } = null;
        public int? Topic { get; set; } = null;
        public string Body { get; set; } = string.Empty;
        public string? MediaUrl { get; set; } = null;
        public int MediaType { get; set; } = 0;
        public bool IsUpdated { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public bool IsArchived { get; set; } = false;
        public bool IsPromoted { get; set; } = false;
        public bool IsNSFW { get; set; } = false;
        public PostEntity ToEntity() {
            return new PostEntity {
                Id = Id,
                UserId = UserId,
                Category = Category,
                Type = Type,
                Topic = Topic,
                Body = Body,
                MediaUrl = MediaUrl,
                MediaType = MediaType,
                IsUpdated = IsUpdated,
                IsDeleted = IsDeleted,
                IsArchived = IsArchived,
                IsPromoted = IsPromoted,
                IsNSFW = IsNSFW
            };
        }
    }
}
