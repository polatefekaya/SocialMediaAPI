using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Domain.Data.Identity;
using RosanicSocial.Domain.DTO.Request.Account;
using RosanicSocial.WebAPI.Controllers;

namespace RosanicSocial.API.Controllers.v1 {
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AccountController : CustomControllerBase {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager) {
            _userManger = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostRegister(RegisterRequest request) {
            if (!ModelState.IsValid) {
                string errorMessage = string.Join(" | ", 
                    ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return Problem(errorMessage);
            }

            ApplicationUser user = new ApplicationUser() {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Username
            };
            IdentityResult result = await _userManger.CreateAsync(user, request.Password);
            if (result.Succeeded) {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(user);
            }

            string errorDesc = string.Join(" | ", result.Errors.Select(x => x.Description));
            return Problem(errorDesc);
        }

        [HttpGet]
        public async Task<IActionResult> IsUsernameAlreadyRegistered(string usernanme) {
            ApplicationUser? user = await _userManger.FindByNameAsync(usernanme);

            if (user == null) {
                return Ok(true);
            } else {
                return Ok(false);
            }
        }
    }
}
