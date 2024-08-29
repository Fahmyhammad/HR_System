using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Domin.Entity
{
    public class OfficialVacation
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="الاسم مطلوب.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "التاريخ مطلوب..")]
        [DisplayName("التاريخ")]
        public DateTime dateTime { get; set; }

    }
}
