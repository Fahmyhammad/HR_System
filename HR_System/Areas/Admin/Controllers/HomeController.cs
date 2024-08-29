using HR_Domin.Constants;
using HR_Infarstuructre.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        [Authorize(Permissions.Home.View)]
        public IActionResult Index()
        {
             ViewBag.ListEmployees = _db.Employees.ToList().Count();
            ViewBag.ListUsers = _db.Users.Count();
            ViewBag.CountTheAudience = _db.Absences.Where(x => x.theAudience == HR_Domin.Helper.TheAudience.غياب).Count();
            ViewBag.CountAttendanceTime = _db.Absences.Where(x => x.theAudience == HR_Domin.Helper.TheAudience.حضور).Count();
            return View();
        }
        [AllowAnonymous]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
