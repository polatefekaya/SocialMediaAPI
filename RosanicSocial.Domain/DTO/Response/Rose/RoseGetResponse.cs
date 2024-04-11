using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Rose {
    public class RoseGetResponse {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid AuthorId { get; set; } = Guid.Empty;
        public Guid NumbersId { get; set; } = Guid.Empty;
        public Guid? StatisticId { get; set; } = null;
        public int? CategoryId { get; set; } = null;
        public int? TypeId { get; set; } = null;
        public string? Message { get; set; } = string.Empty;
        public string? MediaUrl { get; set; } = null;
        public bool? IsUpdated { get; set; } = false;
        public bool? IsDeleted { get; set; } = false;
        public bool? IsNSFW { get; set; } = false;
        public bool? IsPlainText { get; set; } = false;
        public bool? IsPhoto { get; set; } = false;
        public bool? IsVideo { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime? UpdatedAt { get; set; } = DateTime.MinValue;
    }

    public static partial class RoseExtensions {
        public static RoseGetResponse ToGetResponse (this RoseEntity entity) {
            return new RoseGetResponse {
                Id = entity.Id,
                AuthorId = entity.AuthorId,
                NumbersId = entity.NumbersId,
                StatisticId = entity.StatisticId,
                CategoryId = entity.CategoryId,
                TypeId = entity.TypeId,
                Message = entity.Message,
                MediaUrl = entity.MediaUrl,
                IsUpdated = entity.IsUpdated,
                IsDeleted = entity.IsDeleted,
                IsNSFW = entity.IsNSFW,
                IsPlainText = entity.IsPlainText,
                IsPhoto = entity.IsPhoto,
                IsVideo = entity.IsVideo,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
