using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Reports.Block {
    public class BlockAddResponse {
        public int UserId { get; set; }
        public int BlockedUserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class UserBlockEntityExtensions {
        public static BlockAddResponse ToAddResponse(this UserBlockEntity entity) {
            return new BlockAddResponse {
                UserId = entity.UserId,
                BlockedUserId = entity.BlockedUserId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
