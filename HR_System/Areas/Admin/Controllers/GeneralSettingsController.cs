using HR_Domin.Constants;
using HR_Domin.Entity;
using HR_Infarstuructre.Data;
using HR_Infarstuructre.IRepoistory;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using static HR_Domin.Constants.Permissions;

namespace HR_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GeneralSettingsController : Controller
    {

        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public GeneralSettingsController(AppDbContext db,IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }
        [Authorize(Permissions.GeneralSettings.View)]
        public async Task<IActionResult> Index()
        {
            //var settings = _db.GeneralSettings.Include(g => g.employee).ToList();
            var settings =await _unitOfWork.Setting.GetAll(IncludeWord: "employee");
            var model = new ReneralSettViewModel
            {
                listSetting = settings,
                EmpList = _db.Employees.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            return View(model);
        }
        [Authorize(Permissions.GeneralSettings.View)]

        public IActionResult Settings()
        {
            var model = new ReneralSettViewModel
            {
                generalSetting = new GeneralSetting(),
                EmpList = _db.Employees.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.GeneralSettings.Create)]
        [Authorize(Permissions.GeneralSettings.Edit)]
        public async Task<IActionResult> AddSetting(ReneralSettViewModel model)
        {
            if (model == null || model.generalSetting == null)
            {
                TempData["ErrorMessage"] = "بيانات الموظف غير صحيحة.";
                return RedirectToAction("Index");
            }

           // var employee = await _db.Employees.FindAsync(model.generalSetting.employeeId);
            var employee = await _unitOfWork.employee.GetById(x => x.Id == model.generalSetting.employeeId);
            if (employee == null)
            {
                TempData["ErrorMessage"] = "الموظف غير موجود.";
                return RedirectToAction("Index");
            }


            if (string.IsNullOrEmpty(model.generalSetting.Id))
            {
                var newSetting = new GeneralSetting
                {
                    Id = Guid.NewGuid().ToString(),
                    Extra = model.generalSetting.Extra,
                    Rival = model.generalSetting.Rival,
                    dateTime = model.generalSetting.dateTime,
                    OfficialLeave1 = model.generalSetting.OfficialLeave1,
                    OfficialLeave2 = model.generalSetting.OfficialLeave2,
                    employeeId = model.generalSetting.employeeId

                };

                //await _db.GeneralSettings.AddAsync(newSetting);
                //await _db.SaveChangesAsync();
                await _unitOfWork.Setting.Add(newSetting);
                await _unitOfWork.Complete();

                employee.Salary += _unitOfWork.Setting.CalculateSalaryIncrease(model.generalSetting.Extra,employee.HourlyPrice);
                employee.Salary -= _unitOfWork.Setting.CalculateSalaryIncrease(model.generalSetting.Rival,employee.HourlyPrice);
                _db.Employees.Update(employee);
                await _unitOfWork.Complete();

                TempData["SuccessMessage"] = "تم إنشاء العنصر الجديد بنجاح.";
            }
            else
            {
                //var updateSetting = await _db.GeneralSettings.FindAsync(model.generalSetting.Id);
                var updateSetting = await _unitOfWork.Setting.GetById(x => x.Id == model.generalSetting.Id);
                if (updateSetting == null)
                {
                    TempData["ErrorMessage"] = "الموظف غير موجود.";
                    return RedirectToAction("Index");
                }

                updateSetting.Extra = model.generalSetting.Extra;
                updateSetting.Rival = model.generalSetting.Rival;
                updateSetting.dateTime = model.generalSetting.dateTime;
                updateSetting.OfficialLeave1 = model.generalSetting.OfficialLeave1;
                updateSetting.OfficialLeave2 = model.generalSetting.OfficialLeave2;
                updateSetting.employeeId = model.generalSetting.employeeId;

                await _unitOfWork.Setting.Edit(updateSetting);
                await _unitOfWork.Complete();

                employee.Salary += _unitOfWork.Setting.CalculateSalaryIncrease(model.generalSetting.Extra, employee.HourlyPrice);
                employee.Salary -= _unitOfWork.Setting.CalculateSalaryIncrease(model.generalSetting.Rival, employee.HourlyPrice);
                await _unitOfWork.employee.Edit(employee);
                await _unitOfWork.Complete();

                TempData["EditMessage"] = "تم تعديل العنصر بنجاح.";
            }

            return RedirectToAction("Index");
        }
        [Authorize(Permissions.GeneralSettings.Delete)]
        public async Task<IActionResult> DeleteSettingEmps(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "لم يتم توفير معرف الموظف.";
                return RedirectToAction("Index");
            }

            //var settingemps = await _db.GeneralSettings.FirstOrDefaultAsync(x => x.Id == id);
            var settingemps = await _unitOfWork.Setting.GetById(x => x.Id == id);
            if (settingemps == null)
            {
                TempData["ErrorMessage"] = " اعدادات الموظف غير موجود.";
                return RedirectToAction("Index");
            }

            //_db.GeneralSettings.Remove(settingemps);
            //var result = await _db.SaveChangesAsync();
            await _unitOfWork.Setting.Remove(settingemps);
            await _unitOfWork.Complete();

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
