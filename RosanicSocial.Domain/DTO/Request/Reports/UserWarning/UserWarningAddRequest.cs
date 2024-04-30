using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.UserWarning {
    public class UserWarningAddRequest {
        public int UserId { get; set; }
        public int WarningCategory { get; set; }
        public int WarningLevel { get; set; }

        public UserWarningEntity ToEntity() {
            return new UserWarningEntity {
                UserId = UserId,
                WarningCategory = WarningCategory,
                WarningLevel = WarningLevel
            };
        }
    }
}
