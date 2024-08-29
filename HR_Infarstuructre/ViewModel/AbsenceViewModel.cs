using HR_Domin.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class AbsenceViewModel
    {
        public Absence absence { get; set; }
        public IEnumerable<Absence> absenceList {  get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> listItems { get; set; }
    }
}
