using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RosanicSocial.Domain.DTO.Request.Reports.Block {
    public class BlockAddRequest {
        public int UserId { get; set; }
        public int BlockedUserId { get; set; }

        public UserBlockEntity ToEntity() {
            return new UserBlockEntity {
                UserId = UserId,
                BlockedUserId = BlockedUserId
            };
        }
    }
}
