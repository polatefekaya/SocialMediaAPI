using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities.Post
{
    public class RoseEntity
    {
        [Key]
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
        public bool IsNSFW { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime? UpdatedAt { get; set; } = DateTime.MinValue;
    }
}
