using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HR_Domin.Helper;

namespace HR_Domin.Entity
{
    public class Absence
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال القسمز.")]
        public string Department {  get; set; }
        [Required(ErrorMessage = "يجب ادخال الحاله.")]
        public TheAudience theAudience { get; set; }
        //الحضور
        public DateTime AttendanceTime { get; set; }
        // الانصراف
        public DateTime DepartureDate { get; set; }
        [Required(ErrorMessage = "يجب ادخال التاريخ..")]
        public DateTime dateTime { get; set; }

        public string employeeId {  get; set; }
        public Employee employee { get; set; }
    }
}
