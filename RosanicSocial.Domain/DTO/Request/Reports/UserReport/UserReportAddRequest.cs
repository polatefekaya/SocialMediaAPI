using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.UserReport {
    public class UserReportAddRequest {
        public int UserId { get; set; }
        public string? Reason { get; set; }
        public int ReportType { get; set; }

        public UserReportEntity ToEntity() {
            return new UserReportEntity {
                UserId = UserId,
                Reason = Reason,
                ReportType = ReportType
            };
        }
    }
}
