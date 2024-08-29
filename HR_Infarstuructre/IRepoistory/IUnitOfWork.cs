using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.IRepoistory
{
    public interface IUnitOfWork : IDisposable
    {
        IAbsenceRepoistory Absence { get; }

        IEmployeeRepoistory employee { get; }
        IGeneralRepoistory Setting { get; }

        IOfficialRpoistory official { get; }
       Task Complete();
    }
}
