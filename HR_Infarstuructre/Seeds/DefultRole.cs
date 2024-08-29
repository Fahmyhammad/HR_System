using HR_Domin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.Seeds
{
    public class DefultRole
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
           // if (!roleManager.Roles.Any())
            //{
                await roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await roleManager.CreateAsync(new IdentityRole(Helper.Editor));
                await roleManager.CreateAsync(new IdentityRole(Helper.Employees));
            //}
        }
    }
}
