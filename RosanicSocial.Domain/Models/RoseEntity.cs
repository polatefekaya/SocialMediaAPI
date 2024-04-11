using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Models
{
    public class RoseEntity
    {
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
}
