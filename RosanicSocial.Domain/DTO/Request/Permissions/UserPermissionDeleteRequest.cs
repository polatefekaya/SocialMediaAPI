using RosanicSocial.Domain.Data.Entities;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Permissions {
    public class UserPermissionDeleteRequest {
        public int UserId { get; set; }
    }
}
