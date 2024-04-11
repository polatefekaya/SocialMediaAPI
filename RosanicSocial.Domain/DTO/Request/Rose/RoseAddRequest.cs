using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Rose {
    public class RoseAddRequest {
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        [MaxLength(320)]
        public string? Message { get; set; }
        [Required]
        [Range(0,255)]
        public int? CategoryId { get; set; }
        [Range(0,255)]
        public int? TypeId { get; set; }
        public bool IsNSFW { get; set; }
        public bool IsPlainText { get; set; }
        public bool IsPhoto { get; set; }
        public bool IsVideo { get; set; }
        [MaxLength(255)]
        public string? MediaUrl { get; set; }

        public RoseEntity ToEntity() {
            return new RoseEntity() { 
                AuthorId = this.AuthorId,
                Message = this.Message,
                CategoryId = this.CategoryId,
                TypeId = this.TypeId,
                IsNSFW = this.IsNSFW,
                IsPlainText = this.IsPlainText,
                IsPhoto = this.IsPhoto,
                IsVideo = this.IsVideo,
                MediaUrl = this.MediaUrl
            };
        }
    }
}
