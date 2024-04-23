using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities.Report
{
    public class UserWarningEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int WarningCategory { get; set; }
        public int WarningLevel { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
