namespace RosanicSocial.Domain.Models
{
    public class RoseEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid AuthorId { get; set; } = Guid.Empty;
        public Guid NumbersId { get; set; } = Guid.Empty;
        public Guid StatisticId { get; set; } = Guid.Empty;
        public string? AuthorUsername { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public DateTime? PostDate { get; set; } = DateTime.MinValue;
        public bool? IsUpdated = false;
        public bool? IsDeleted = false;
        public DateTime? CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime? UpdatedAt { get; set; } = DateTime.MinValue;
    }
}
