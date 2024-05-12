using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities.Report
{
    public class UserBlockEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlockedUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
