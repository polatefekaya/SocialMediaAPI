﻿using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Post
{
    public class PostAddResponse {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; } = 0;
        public int? Type { get; set; } = null;
        public int? Topic { get; set; } = null;
        public string? Body { get; set; } = null;
        public string? MediaUrl { get; set; } = null;
        public int MediaType { get; set; } = 0;
        public bool IsUpdated { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public bool IsArchived { get; set; } = false;
        public bool IsPromoted { get; set; } = false;
        public bool IsNSFW { get; set; } = false;
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostEntityExtensions {
        public static PostAddResponse ToAddResponse(this PostEntity entity) {
            return new PostAddResponse {
                Id = entity.Id,
                UserId = entity.UserId,
                Category = entity.Category,
                Type = entity.Type,
                Topic = entity.Topic,
                Body = entity.Body,
                MediaUrl = entity.MediaUrl,
                MediaType = entity.MediaType,
                IsUpdated = entity.IsUpdated,
                IsDeleted = entity.IsDeleted,
                IsArchived = entity.IsArchived,
                IsPromoted = entity.IsPromoted,
                IsNSFW = entity.IsNSFW,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
