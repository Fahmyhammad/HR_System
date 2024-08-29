using HR_Domin.Entity;
using HR_Infarstuructre.Data;
using HR_Infarstuructre.IRepoistory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.ServicesRepository
{
    public class AbsenceRepoistory : GenericRepositery<Absence>, IAbsenceRepoistory
    {
        private readonly AppDbContext _db;
        public AbsenceRepoistory(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Edit(Absence entity)
        {
            if (entity != null)
                _db.Update(entity);
        }
    }
}
