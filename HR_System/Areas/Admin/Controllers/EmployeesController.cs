using HR_Domin.Entity;
using HR_Infarstuructre.Data;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using HR_Domin.Constants;
using HR_Infarstuructre.IRepoistory;
using static HR_Domin.Constants.Permissions;

namespace HR_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(AppDbContext db,IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }
        [Authorize(Permissions.Employees.View)]
        public async Task<IActionResult> Index()
        {
            // var employees = _db.Employees.ToList();
            var employees =await _unitOfWork.employee.GetAll();
            var model = new EmployeeViewModel
            {
                Listemp = employees.Select(employee => new Employee
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = employee.Address,
                    PhoneNumber = employee.PhoneNumber,
                    Genders = employee.Genders,
                    Nationality = employee.Nationality,
                    HourlyPrice = employee.HourlyPrice,
                    Date = employee.Date,
                    NationalID = employee.NationalID,
                    RetirementDate = employee.RetirementDate,
                    Salary = employee.Salary,
                    AttendanceTime = employee.AttendanceTime,
                    DepartureDate = employee.DepartureDate
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.Employees.Create)]
        [Authorize(Permissions.Employees.Edit)]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
        {
            if (model == null || model.NewEmployee == null)
            {
                TempData["ErrorMessage"] = "بيانات الموظف غير صحيحة.";
                return RedirectToAction("Index");
            }

            if (string.IsNullOrEmpty(model.NewEmployee.Id)) // Create
            {
                var newEmp = new Employee
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.NewEmployee.Name,
                    Address = model.NewEmployee.Address,
                    PhoneNumber = model.NewEmployee.PhoneNumber,
                    Genders = model.NewEmployee.Genders,
                    Nationality = model.NewEmployee.Nationality,
                    HourlyPrice = model.NewEmployee.HourlyPrice,
                    Date = model.NewEmployee.Date,
                    NationalID = model.NewEmployee.NationalID,
                    AttendanceTime = model.NewEmployee.AttendanceTime,
                    DepartureDate = model.NewEmployee.DepartureDate,
                    RetirementDate = model.NewEmployee.RetirementDate,
                    Salary = model.NewEmployee.Salary,
                };

                //await _db.Employees.AddAsync(newEmp);
                await _unitOfWork.employee.Add(newEmp);
                //await _db.SaveChangesAsync();
                await _unitOfWork.Complete();

                TempData["SuccessMessage"] = "تم إنشاء العنصر الجديد بنجاح.";
            }
            else // Update
            {
                // var existingEmp = await _db.Employees.FindAsync(model.NewEmployee.Id);
                var existingEmp = await _unitOfWork.employee.GetById(x => x.Id == model.NewEmployee.Id);
                if (existingEmp == null)
                {
                    TempData["ErrorMessage"] = "الموظف غير موجود.";
                    return RedirectToAction("Index");
                }

                existingEmp.Name = model.NewEmployee.Name;
                existingEmp.Address = model.NewEmployee.Address;
                existingEmp.PhoneNumber = model.NewEmployee.PhoneNumber;
                existingEmp.Genders = model.NewEmployee.Genders;
                existingEmp.Nationality = model.NewEmployee.Nationality;
                existingEmp.HourlyPrice = model.NewEmployee.HourlyPrice;
                existingEmp.Date = model.NewEmployee.Date;
                existingEmp.NationalID = model.NewEmployee.NationalID;
                existingEmp.AttendanceTime = model.NewEmployee.AttendanceTime;
                existingEmp.DepartureDate = model.NewEmployee.DepartureDate;
                existingEmp.RetirementDate = model.NewEmployee.RetirementDate;
                existingEmp.Salary = model.NewEmployee.Salary;

                //_db.Employees.Update(existingEmp);
                //await _db.SaveChangesAsync();

                await _unitOfWork.employee.Edit(existingEmp);
                await _unitOfWork.Complete();

                TempData["EditMessage"] = "تم تعديل العنصر بنجاح.";
            }

            return RedirectToAction("Index");
        }

        [Authorize(Permissions.Employees.Delete)]
        public async Task<IActionResult> DeleteEmps(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "لم يتم توفير معرف الموظف.";
                return RedirectToAction("Index");
            }

            //  var emps = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            var emps = await _unitOfWork.employee.GetById(x => x.Id == id);
            if (emps == null)
            {
                TempData["ErrorMessage"] = "الموظف غير موجود.";
                return RedirectToAction("Index");
            }

          await _unitOfWork.employee.Remove(emps);
             await _unitOfWork.Complete();

            //if (result > 0)
            //{
                TempData["DeleteMessage"] = "تم حذف الموظف بنجاح.";
            //}
            //else
            //{
            //    TempData["ErrorMessage"] = "حدث خطأ أثناء محاولة حذف الموظف.";
            //}

            return RedirectToAction("Index");
        }


    }
}
