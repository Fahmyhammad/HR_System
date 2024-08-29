using HR_Domin;
using HR_Domin.Constants;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static HR_Domin.Helper;

namespace HR_Infarstuructre.Seeds
{
    public static class DefultUser
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            var Defultuser = new AppUser
            {
                UserName = Helper.UserName,
                Email = Helper.Email,
                Name = Helper.Name,
                ActiveUser=true,
                EmailConfirmed= true
            };

            var user = userManager.FindByEmailAsync(Defultuser.Email);

            if(user.Result == null)
            {
                await userManager.CreateAsync(Defultuser,Helper.Password);
                await userManager.AddToRoleAsync(Defultuser, Helper.Admin);
            }

            await roleManager.SeedClaimsAsync();
        }

        public static async Task SeedClaimsAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Helper.Admin);
            // Code Add Permission Claims
            var modules = Enum.GetValues(typeof(PermissionModuleName));
            foreach (var module in modules)
            {
                await roleManager.AddPermissionClaims(module.ToString(),adminRole);
            }
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager,string module,IdentityRole role)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsFromModel(module);
            foreach (var Permission in allPermissions)
            {
                if(!allClaims.Any(x=>x.Type == "Permission" && x.Value == Permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", Permission));
                }
            }
        }
    }
}
