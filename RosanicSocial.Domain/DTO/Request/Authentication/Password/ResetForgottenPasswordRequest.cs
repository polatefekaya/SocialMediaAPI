using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Authentication.Password {
    public class ResetForgottenPasswordRequest {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must be the same.")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
