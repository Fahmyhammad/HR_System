using HR_Domin;
using HR_Domin.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class RegisterViewModel
    {
        public List<VwUser> Users { get; set; }
        public NewRegister NewRegister { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public ChangePasswordViewModel changePassword { get; set; }
    }

    public class NewRegister
    {
        [Key]
        public string Id { get;set; }
        [Required(ErrorMessageResourceType = typeof(Helper),ErrorMessageResourceName = "ErrorName")]
        [MaxLength(20, ErrorMessageResourceType = typeof(Helper),ErrorMessageResourceName = "ErrorMaxLenthe")]
        [MinLength(3, ErrorMessageResourceType = typeof(Helper),ErrorMessageResourceName = "ErrorMinLenthe")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper),ErrorMessageResourceName = "ErrorRoleName")]
        public string RoleName {  get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorEmailSuccessed")]
        public string Email { get; set; }
        public bool ActiveUser { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorPassword")]
        public string Password { get; set; }
        [Required(ErrorMessageResourceType = typeof(Helper), ErrorMessageResourceName = "ErrorCompPass")]
        [Compare("Password", ErrorMessageResourceType = typeof(Helper),ErrorMessageResourceName = "ErrorCompPassSuccessed")]
        public string ComperPassword { get; set; }

    }
}
