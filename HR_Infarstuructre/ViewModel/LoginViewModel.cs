using HR_Domin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorEmailSuccessed")]
        public string Email {  get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorPassword")]
        public string Password { get; set; }
        public bool RememberMe {  get; set; }
    }
}
