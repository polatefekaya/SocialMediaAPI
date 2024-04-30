using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Info.Detailed {
    public class DetailedInfoUpdateResponse {
        public int UserId { get; set; }
        public string? Biography { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class DetailedInfoEntityExtesions {
        public static DetailedInfoUpdateResponse ToUpdateResponse(this DetailedInfoEntity entity) {
            return new DetailedInfoUpdateResponse {
                UserId = entity.UserId,
                Biography = entity.Biography,
                Country = entity.Country,
                Gender = entity.Gender,
                ProfilePhotoUrl = entity.ProfilePhotoUrl,
                WebsiteUrl = entity.WebsiteUrl,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
