using HR_Domin;
using HR_Domin.Constants;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HR_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PermissionsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public PermissionsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(PermissionViewModel model)
        {
            if (string.IsNullOrEmpty(model.RoleId))
            {
                return BadRequest("RoleId cannot be null or empty.");
            }

            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
            {
                return NotFound($"Role with ID '{model.RoleId}' not found.");
            }

            var claims = _roleManager.GetClaimsAsync(role).Result.Select(x => x.Value).ToList();
            var allPermissions = Permissions.PermissionsList()
                                   .Select(x => new RoleClaimsViewModel { Value = x }).ToList();

            foreach (var Permission in allPermissions)
            {
                if (claims.Any(x => x == Permission.Value))
                    Permission.Selected = true;
            }

            return View(new PermissionViewModel
            {
                RoleId = model.RoleId,
                RoleName = role.Name,
                RoleClaims = allPermissions
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var SelectedClaims = model.RoleClaims.Where(x => x.Selected).ToList();
            foreach (var claim in SelectedClaims)
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.Value));
            }
            return RedirectToAction("Roles","Accounts");
        }
    }
}
