﻿using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.Data.Entities.Report {
    public class UserReportEntity {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string? Reason { get; set; }
        public int ReportType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
