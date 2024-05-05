using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Account {
    public class LoginRequest {
        [Required(ErrorMessage = "UserName can't be blank")]
        public string? UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password can't be blank")]
        public string? Password { get; set; } = string.Empty;
    }
}
