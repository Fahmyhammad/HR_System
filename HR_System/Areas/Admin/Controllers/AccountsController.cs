using HR_Domin.Constants;
using HR_Domin.Entity;
using HR_Infarstuructre.Data;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountsController(RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signIn, UserManager<AppUser> userManager, AppDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
            _signInManager = signIn;
        }
        [Authorize(Permissions.Accounts.View)]
        public IActionResult Roles()
        {
            return View(new RolesViewModel
            {
                NewRole = new NewRole(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.Accounts.Create)]
        public async Task<IActionResult> Roles(RolesViewModel model)
        {
            if (model != null)
            {
                var role = new IdentityRole
                {
                    Id = model.NewRole.RoleId,
                    Name = model.NewRole.RoleName
                };
                //Create
                if (role.Id == null)
                {
                    role.Id = Guid.NewGuid().ToString();
                    var result = await _roleManager.CreateAsync(role);
                    //Succeeded
                    if (result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "تم إنشاء العنصر الجديد بنجاح.";
                        return RedirectToAction("Roles");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "حدث خطأ أثناء إنشاء العنصر الجديد.";
                    }
                }
                //Update
                else
                {

                    var roleUpdate = await _roleManager.FindByIdAsync(role.Id);

                    roleUpdate.Id = model.NewRole.RoleId;
                    roleUpdate.Name = model.NewRole.RoleName;
                    var result = await _roleManager.UpdateAsync(roleUpdate);

                    if (result.Succeeded)
                    {
                        TempData["EditMessage"] = "تم تعديل العنصر بنجاح.";
                        return RedirectToAction("Roles");
                    }

                    TempData["ErrorEdit"] = "حدث خطأ أثناء تعديل العنصر.";
                    return RedirectToAction("Roles");


                }
            }
            return View();
        }

        [Authorize(Permissions.Accounts.Delete)]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    TempData["DeleteMessage"] = "تم حذف مجموعة المستخدم.";
                }
                else
                {
                    TempData["ErrorMessage"] = "حدث خطأ أثناء محاولة حذف مجموعة المستخدم.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "مجموعة المستخدم غير موجودة.";
            }
            return RedirectToAction("Roles");
        }


        [Authorize(Permissions.Accounts.View)]
        public async Task<IActionResult> Register()
        {
            var users = _userManager.Users.ToList();
            var usersWithRoles = new List<VwUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault();

                usersWithRoles.Add(new VwUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    RoleName = roleName,
                    ActiveUser = user.ActiveUser
                });
            }

            var model = new RegisterViewModel
            {
                Users = usersWithRoles,
                Roles = await _roleManager.Roles.ToListAsync()
            };

            return View(model);
        }

        [Authorize(Permissions.Accounts.Create)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registers(RegisterViewModel model)
        {
            if (model != null)
            {
                var user = new AppUser
                {
                    Id = model.NewRegister.Id,
                    Name = model.NewRegister.Name,
                    Email = model.NewRegister.Email,
                    UserName = model.NewRegister.Email,
                    ActiveUser = model.NewRegister.ActiveUser
                };
                //Create
                if (user.Id == null)
                {
                    user.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(user, model.NewRegister.Password);
                    if (result.Succeeded)
                    {
                        var Role = await _userManager.AddToRoleAsync(user, model.NewRegister.RoleName);
                        if (Role.Succeeded)
                        {
                            TempData["SuccessMessage"] = "تم إنشاء العنصر الجديد بنجاح.";
                            return RedirectToAction("Register");
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "حدث خطأ أثناء إنشاء العنصر الجديد.";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "حدث خطأ أثناء إنشاء العنصر الجديد.";
                    }

                }
                else
                {
                    var userUdate = await _userManager.FindByIdAsync(user.Id);
                    userUdate.Name = model.NewRegister.Name;
                    userUdate.UserName = model.NewRegister.Email;
                    userUdate.Email = model.NewRegister.Email;
                    userUdate.ActiveUser = model.NewRegister.ActiveUser;

                    var result = await _userManager.UpdateAsync(userUdate);
                    if (result.Succeeded)
                    {
                        var OldRole = await _userManager.GetRolesAsync(userUdate);
                        await _userManager.RemoveFromRolesAsync(userUdate, OldRole);
                        var AddRole = await _userManager.AddToRoleAsync(userUdate, model.NewRegister.RoleName);
                        if (AddRole.Succeeded)
                        {
                            TempData["EditMessage"] = "تم تعديل العنصر بنجاح.";
                            return RedirectToAction("Register");
                        }
                        else
                        {
                            TempData["ErrorEdit"] = "حدث خطأ أثناء تعديل العنصر.";
                            return RedirectToAction("Register");
                        }

                    }
                    else
                    {
                        TempData["ErrorEdit"] = "حدث خطأ أثناء تعديل العنصر.";
                        return RedirectToAction("Register");
                    }

                }
                return RedirectToAction("Register", "Accounts");

            }
            return RedirectToAction("Register", "Accounts");
        }

        [Authorize(Permissions.Accounts.Delete)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            if ((await _userManager.DeleteAsync(user)).Succeeded)
            {
                TempData["DeleteMessage"] = "تم حذف مجموعة المستخدم.";
                return RedirectToAction("Register");
            }
            else
            {
                TempData["ErrorMessage"] = "حدث خطأ أثناء محاولة حذف مجموعة المستخدم.";
                return RedirectToAction("Register");

            }
        }
        [Authorize(Permissions.Accounts.Create)]
        public async Task<IActionResult> ChangePass(RegisterViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.changePassword.Id);
            if (user != null)
            {
                await _userManager.RemovePasswordAsync(user);
                var ChangeNewPass = await _userManager.AddPasswordAsync(user, model.changePassword.NewPassword);
                if (ChangeNewPass.Succeeded)
                {
                    TempData["EditMessage"] = "تم تعديل العنصر بنجاح.";
                    return RedirectToAction("Register");
                }
                else
                {
                    TempData["ErrorEdit"] = "حدث خطأ أثناء تعديل العنصر.";
                    return RedirectToAction("Register");
                }
            }
            TempData["ErrorMessage"] = "حدث خطأ أثناء تعديل العنصر.";
            return RedirectToAction("Register");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    ViewBag.ErrorLogin = false;

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
