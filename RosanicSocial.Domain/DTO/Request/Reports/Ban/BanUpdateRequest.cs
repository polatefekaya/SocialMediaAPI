using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Reports.Ban {
    public class BanUpdateRequest {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; }
        public bool IsCritical { get; set; }
        public string? Reason { get; set; }
        public UserBanEntity ToEntity() {
            return new UserBanEntity {
                Id = Id,
                UserId = UserId,
                Category = Category,
                IsCritical = IsCritical,
                Reason = Reason
            };
        }
    }
}
