using HR_Domin.Entity;
using HR_Infarstuructre.Data;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using HR_Domin.Constants;
using HR_Infarstuructre.IRepoistory;

namespace HR_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AbsenceController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public AbsenceController(AppDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }
        [Authorize(Permissions.Absence.View)]
        public async Task<IActionResult> Index()
        {
             //var result = _db.Absences.OrderBy(b=>b.dateTime).Include(x=>x.employee).ToList();
             var result =await _unitOfWork.Absence.GetAll(IncludeWord:"employee");
             var model = new AbsenceViewModel
             {
                absenceList = result.OrderByDescending(x=>x.dateTime),
                listItems = _db.Employees.ToList().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })

             };
            return View(model);
        }
        [Authorize(Permissions.Absence.Create)]
        [Authorize(Permissions.Absence.Edit)]
        public async Task<IActionResult> AddAbsence(AbsenceViewModel model)
        {
            if (model == null || model.absence == null)
            {
                TempData["ErrorMessage"] = "بيانات الموظف غير صحيحة.";
                return RedirectToAction("Index");
            }

            if(model.absence.Id == null)
            {
                var absence = new Absence
                {
                    Id = Guid.NewGuid().ToString(),
                    Department = model.absence.Department,
                    AttendanceTime = model.absence.AttendanceTime,
                    theAudience = model.absence.theAudience,
                    DepartureDate = model.absence.DepartureDate,
                    dateTime = model.absence.dateTime,
                    employeeId = model.absence.employeeId
                };

               // await _db.Absences.AddAsync(absence);
                await _unitOfWork.Absence.Add(absence);
                await _unitOfWork.Complete();

                TempData["SuccessMessage"] = "تم إنشاء العنصر الجديد بنجاح.";
            }
            else
            {
                //var absenceValue = await _db.Absences.FindAsync(model.absence.Id);
                var absenceValue = await _unitOfWork.Absence.GetById(x=>x.Id ==  model.absence.Id);
                if (absenceValue == null)
                {
                    TempData["ErrorMessage"] = "الموظف غير موجود.";
                    return RedirectToAction("Index");
                }

                absenceValue.Department = model.absence.Department;
                absenceValue.AttendanceTime = model.absence.AttendanceTime;
                absenceValue.theAudience = model.absence.theAudience;
                absenceValue.DepartureDate = model.absence.DepartureDate;
                absenceValue.dateTime = model.absence.dateTime;
                absenceValue.employeeId = model.absence.employeeId;

                //_db.Absences.Update(absenceValue);
                await _unitOfWork.Absence.Edit(absenceValue);
                await _unitOfWork.Complete();

                TempData["EditMessage"] = "تم تعديل العنصر بنجاح.";

            }
            return RedirectToAction("Index");
        }
        [Authorize(Permissions.Absence.Delete)]
        public async Task<IActionResult> DeleteAbsence(string id)
        {
            if(id == null)
            {

                TempData["ErrorMessage"] = "لم يتم توفير معرف الموظف.";
                return RedirectToAction("Index");
            }

            //var absenceEmp =await _db.Absences.FirstOrDefaultAsync(x => x.Id == id);
            var absenceEmp = await _unitOfWork.Absence.GetById(x => x.Id == id);
            if (absenceEmp == null)
            {
                TempData["ErrorMessage"] = " اعدادات الموظف غير موجود.";
                return RedirectToAction("Index");
            }

            //_db.Absences.Remove(absenceEmp);
            await _unitOfWork.Absence.Remove(absenceEmp);
            await  _unitOfWork.Complete();

            //if (result > 0)
            //{
             TempData["DeleteMessage"] = "تم حذف اعدادات الموظف بنجاح.";
            //}
            //else
            //{
            //    TempData["ErrorMessage"] = "حدث خطأ أثناء محاولة حذف الموظف.";
            //}

            return RedirectToAction("Index");
        }
    }
}
