namespace RosanicSocial.Domain.Models
{
    public class Rose
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid AuthorId { get; set; } = Guid.Empty;
        public Guid NumbersId { get; set; } = Guid.Empty;
        public Guid StatisticId { get; set; } = Guid.Empty;
        public string? AuthorUsername { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public DateTime? PostDate { get; set; } = DateTime.MinValue;
    }
}
