using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementShared.Models;

namespace StudentManagement.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<StudentTable> StudentsTable { get; set; }
        public DbSet<SystemCodeTable> SystemCodesTable { get; set; }
        public DbSet<CountryTable > CountriesTable { get; set; }
        public DbSet<SystemCodeDetailTable> SystemCodesDetailsTable { get; set; }
    }
}
