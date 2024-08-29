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
    public class EmployeeRepoistory : GenericRepositery<Employee>, IEmployeeRepoistory
    {
        private readonly AppDbContext _db;
        public EmployeeRepoistory(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Edit(Employee entity)
        {
            if (entity != null)
                _db.Update(entity);
        }
    }
}
