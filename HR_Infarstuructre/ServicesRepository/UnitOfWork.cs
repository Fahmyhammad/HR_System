using HR_Infarstuructre.Data;
using HR_Infarstuructre.IRepoistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ServicesRepository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Absence = new AbsenceRepoistory(db);
            employee = new EmployeeRepoistory(db);
            Setting = new GeneralRepoistory(db);
            official = new OfficialRepoistory(db);
        }

        public IAbsenceRepoistory Absence { get;private set; }

        public IEmployeeRepoistory employee { get; private set; }
        public IGeneralRepoistory Setting { get; private set; }

        public IOfficialRpoistory official {  get; private set; }

        Task IUnitOfWork.Complete()
        {
            return _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();

        }

      
    }
}
