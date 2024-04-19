using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosanicSocial.Domain.Data.Entities {
    public class BaseInfoEntity {
        [Key]
        public int UserId { get; set; }
        public int PostCount { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
