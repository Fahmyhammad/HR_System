using HR_Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ViewModel
{
    public class OfficialViewModel
    {
        public OfficialVacation Official {  get; set; }

        public IEnumerable<OfficialVacation> OfficialLest { get; set; }
    }
}
