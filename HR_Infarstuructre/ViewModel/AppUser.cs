using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class AppUser : IdentityUser
    {
        public string Name {  get; set; }
        public bool ActiveUser {  get; set; }
    }
}
