using HR_Domin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string Id {  get; set; }

        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorOldPassword")]
        public string OldPassword { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorPassword")]
        public string NewPassword {  get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorCompPass")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorCompPassSuccessed")]
        public string ComparePassword { get; set; }
    }
}
