using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities.Report {
    public class PostReportEntity {
        public Guid Id { get; set; }
        public int PostId { get; set; }
        public string? Reason { get; set; }
        public int ReportType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
