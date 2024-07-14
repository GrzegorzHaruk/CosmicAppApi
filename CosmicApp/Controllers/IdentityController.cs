using CosmicApp.Domain.Constants;
using CosmicApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CosmicApp.Api.Controllers
{
    [ApiController]
    [Route("api/identity/")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Implement after adding CQRS implementation

        //[HttpPatch("user")]
        //public async Task<IActionResult> UpdateUserDetails()
        //{

        //}


        [HttpPost("assignUserRole")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRole([FromQuery] string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _roleManager.FindByNameAsync(roleName!);

            await _userManager.AddToRoleAsync(user, roleName);
            
            return NoContent();
        }

        [HttpPost("unassignUserRole")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UnassignUserRole([FromQuery] string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var role = await _roleManager.FindByNameAsync(roleName!);

            await _userManager.RemoveFromRoleAsync(user, roleName);

            return NoContent();
        }
    }
}
