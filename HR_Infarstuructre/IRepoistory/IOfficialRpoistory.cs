using HR_Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.IRepoistory
{
    public interface IOfficialRpoistory :IGenericRepository<OfficialVacation>
    {
        Task Edit(OfficialVacation entity);
    }
}
