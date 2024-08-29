using HR_Domin.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;

namespace HR_Infarstuructre.ViewModel
{
    public class ReneralSettViewModel
    {
        public GeneralSetting generalSetting { get; set; }
        public IEnumerable<GeneralSetting> listSetting { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EmpList { get; set; }
    }
}
