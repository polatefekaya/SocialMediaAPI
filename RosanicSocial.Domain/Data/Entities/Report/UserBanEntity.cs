using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities.Report
{
    public class UserBanEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int Category { get; set; }
        public bool IsCritical { get; set; }
        public string? Reason { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
