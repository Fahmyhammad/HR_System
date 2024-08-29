using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class RolesViewModel
    {
        public List<IdentityRole> Roles { get; set; }
        public NewRole NewRole { get; set; }
    }
    public class NewRole { 
      
        public string RoleId { get; set; }
        [Required(ErrorMessage = "يجب ادخال الاسم ..")]
        [MaxLength(20, ErrorMessage = "الحد لا يزيد عن عشرين حرف..")]
        [MinLength(3, ErrorMessage = "الحد لا يقل عن ثلاث احرف")]
        public string RoleName { get; set; }

    }
}
