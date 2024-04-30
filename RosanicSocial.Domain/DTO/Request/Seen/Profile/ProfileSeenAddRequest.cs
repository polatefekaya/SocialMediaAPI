using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Seen.Profile {
    public class ProfileSeenAddRequest {
        public int UserId { get; set; }
        public int SeenUserId { get; set; }

        public ProfileSeenEntity ToEntity() {
            return new ProfileSeenEntity {
                UserId = UserId,
                SeenUserId = SeenUserId
            };
        }
    }
}
