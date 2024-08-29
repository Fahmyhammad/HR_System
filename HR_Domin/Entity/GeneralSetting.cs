using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Domin.Entity
{
    public class GeneralSetting
    {
        public string Id { get; set; }

        public int Extra {  get; set; }
        public int Rival {  get; set; }

        [Required(ErrorMessage = "يجب ادخال التاريخ")]
        public DateTime dateTime {  get; set; }

        [Required(ErrorMessage ="اليوم الاول مطلوب..")]
        public string OfficialLeave1 { get; set; }
        [Required(ErrorMessage = "اليوم الثاني مطلوب..")]
        public string OfficialLeave2 { get; set; }
        [DisplayName("اسم الموظف")]
        [Required(ErrorMessage = "اسم الموظف مطلوب..")]
        public string employeeId { get; set; }
        public Employee employee { get; set; }
    }
}
