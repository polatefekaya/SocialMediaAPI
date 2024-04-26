using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Info.Base {
    public class BaseInfoDeleteRequest {
        public int UserId { get; set; }
        public BaseInfoEntity ToEntity() {
            return new BaseInfoEntity {
                UserId = UserId,
            };
        }
    }
}
