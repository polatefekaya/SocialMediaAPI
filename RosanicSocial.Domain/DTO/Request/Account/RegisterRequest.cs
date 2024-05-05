using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Account {
    public class RegisterRequest {
        [Required(ErrorMessage = "First name can't be blank")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name can't be blank")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username can't be blank")]
        [Remote(action: "IsUsernameAlreadyRegistered", controller: "Account", ErrorMessage = "Username is already in use")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain digits only")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
