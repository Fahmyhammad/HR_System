using HR_Domin;
using HR_Domin.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class EmployeeViewModel
    {
        public NewEmployee NewEmployee { get; set; }
        public IEnumerable<Employee> Listemp {  get; set; }
    }

    public class NewEmployee {

        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorMaxLenthe")]
        [MinLength(3, ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorMinLenthe")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorAddress")]
        public string Address { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorPhone")]
        [MaxLength(11, ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorMaxLenthePhone")]
        [MinLength(11, ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorMinLenthePhone")]
        public string PhoneNumber { get; set; }
        public Helper.Gender Genders { get; set; }
        public string Nationality { get; set; }
        [Required(ErrorMessage = " سعر الساعة مطلوب.")]
        public decimal HourlyPrice { get; set; }

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب.")]
        [DataType(DataType.Date)]
        [MinimumAge(20, ErrorMessage = "عمر الموظف يجب أن يكون لا يقل عن 20 عامًا.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorNationalID")]
        [MaxLength(14, ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorMaxLentheNational")]
        [MinLength(14, ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorMinLentheNational")]
        public string NationalID { get; set; }

        public DateTime RetirementDate { get; set; }
        [Required(ErrorMessage = "الراتب مطلوب")]
        public decimal Salary { get; set; }
        //الحضور
        public DateTime AttendanceTime { get; set; }
        // الانصراف
        public DateTime DepartureDate { get; set; }
    }
    
public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;

                if (age < _minimumAge)
                {
                    return new ValidationResult($"عمر الموظف يجب أن يكون لا يقل عن {_minimumAge} عامًا.");
                }
            }

            return ValidationResult.Success;
        }
    }

}
