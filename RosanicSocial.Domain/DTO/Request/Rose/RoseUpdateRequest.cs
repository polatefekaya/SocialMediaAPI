using RosanicSocial.Domain.Data.Entites.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Rose
{
    public class RoseUpdateRequest {
        [Required]
        public Guid Id { get; set; }
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
        
        public RoseEntity ToEntity() {
            return new RoseEntity() {
                Id = this.Id,
                StatisticId = this.StatisticId,
                CategoryId = this.CategoryId,
                TypeId = this.TypeId,
                Message = this.Message,
                MediaUrl = this.MediaUrl,
                IsUpdated = this.IsUpdated,
                IsDeleted = this.IsDeleted,
                IsNSFW = this.IsNSFW,
                IsPlainText = this.IsPlainText,
                IsPhoto = this.IsPhoto,
                IsVideo = this.IsVideo
            };
        }
    }
}
