using HR_Domin.Entity;
using HR_Infarstuructre.Data;
using HR_Infarstuructre.IRepoistory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HR_Domin.Constants.Permissions;

namespace HR_Infarstuructre.ServicesRepository
{
    public class GeneralRepoistory : GenericRepositery<GeneralSetting>, IGeneralRepoistory
    {
        private readonly AppDbContext _db;
        public GeneralRepoistory(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public decimal CalculateSalaryIncrease(decimal extraHours,decimal hourlyRate)
        {
            return extraHours * hourlyRate;
        }

        public async Task Edit(GeneralSetting entity)
        {
            if (entity != null)
                _db.Update(entity);
        }
    }
}
