using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Authentication.Password {
    public class ForgotPasswordRequest {
        [Required]
        public string UserName { get; set; }
    }
}
