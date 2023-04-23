using AppDev.Application.Common.Interface;
using AppDev.Domain.Entities;
using AppDev.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppDev.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<SalaryOrBonus> SalaryOrBonus { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedTime = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedTime = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            var ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new IdentityUser()
            {
                Id = ADMIN_ID,
                Email = "ahumagain64@gmail.com",
                EmailConfirmed = true,
                UserName = "Abhishek Humagain",
                NormalizedUserName = "AHUMAGAIN64@GMAIL.COM"
            };
            
            //set user password
            var ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Admin_12!");

            //seed user
            builder.Entity<IdentityUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            base.OnModelCreating(builder);
        }
    }
}
