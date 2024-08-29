using HR_Domin.Entity;
using HR_Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Infarstuructre.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityUser>().ToTable("Users", "Identity");
            //builder.Entity<IdentityRole>().ToTable("Roles", "Identity");
            //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Identity");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Identity");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Identity");
            //builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Identity");
            builder.Entity<VwUser>().HasNoKey().ToView(nameof(VwUsers));
        }

        public DbSet<VwUser> VwUsers {  get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<OfficialVacation> OfficialVacations { get; set; }
        public DbSet<Absence> Absences { get; set; }
    }
}
