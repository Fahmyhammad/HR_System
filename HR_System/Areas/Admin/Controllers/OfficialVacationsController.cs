using HR_Domin.Constants;
using HR_Domin.Entity;
using HR_Infarstuructre.Data;
using HR_Infarstuructre.IRepoistory;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static HR_Domin.Constants.Permissions;

namespace HR_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfficialVacationsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public OfficialVacationsController(AppDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Permissions.OfficialVacations.View)]
        public async Task<IActionResult> Index()
        {
            //var result = _db.OfficialVacations.OrderBy(x=>x.dateTime).ToList();
            var result =await _unitOfWork.official.GetAll();
            var model = new OfficialViewModel
            {
                OfficialLest = result.Select(official => new OfficialVacation
                {
                    Id = official.Id,
                    Name = official.Name,
                    dateTime = official.dateTime
                   
                }).OrderBy(x=>x.dateTime).ToList()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.OfficialVacations.Create)]
        [Authorize(Permissions.OfficialVacations.Edit)]
        public async Task<IActionResult> AddOfficial(OfficialViewModel modle)
        {

            if (modle == null || modle.Official == null)
            {
                TempData["ErrorMessage"] = "بيانات الموظف غير صحيحة.";
                return RedirectToAction("Index");
            }

            if (string.IsNullOrEmpty(modle.Official.Id))
            {
                var officialmodel = new OfficialVacation
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = modle.Official.Name,
                    dateTime = modle.Official.dateTime
                };

                //await _db.OfficialVacations.AddAsync(officialmodel);
                //await _db.SaveChangesAsync();
                await _unitOfWork.official.Add(officialmodel);
                await _unitOfWork.Complete();

                TempData["SuccessMessage"] = "تم إنشاء العنصر الجديد بنجاح.";
            }
            //update
            else
            {

                //var updateOfficial =await _db.OfficialVacations.FindAsync(modle.Official.Id);
                var updateOfficial = await _unitOfWork.official.GetById(x => x.Id == modle.Official.Id);
                if (updateOfficial == null)
                {
                    TempData["ErrorMessage"] = "التاريخ غير موجود.";
                    return RedirectToAction("Index");
                }

                updateOfficial.Name = modle.Official.Name;
                updateOfficial.dateTime = modle.Official.dateTime;

                await _unitOfWork.official.Edit(updateOfficial);
                await _unitOfWork.Complete();


                TempData["EditMessage"] = "تم تعديل العنصر بنجاح.";

            }
            return RedirectToAction("Index");

        }
        [Authorize(Permissions.OfficialVacations.Delete)]
        public async Task<IActionResult> DeleteOfficial(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "لم يتم توفير معرف التاريخ.";
                return RedirectToAction("Index");
            }

            //var deleteOfficial =await _db.OfficialVacations.FirstOrDefaultAsync(x=>x.Id == id);
            var deleteOfficial = await _unitOfWork.official.GetById(x => x.Id == id);
            if (deleteOfficial == null)
            {
                TempData["ErrorMessage"] = " تاريخ الاجازه غير موجود.";
                return RedirectToAction("Index");
            }

            //_db.OfficialVacations.Remove(deleteOfficial);
            //var result = await _db.SaveChangesAsync();

            await _unitOfWork.official.Remove(deleteOfficial);
            await _unitOfWork.Complete();

            //if (result > 0)
            //{
            TempData["DeleteMessage"] = "تم حذف تاريخ الاجازه بنجاح.";
            //}
            //else
            //{
            //    TempData["ErrorMessage"] = "حدث خطأ أثناء محاولة حذف التاريخ.";
            //}

            return RedirectToAction("Index");

        }

    }
}
