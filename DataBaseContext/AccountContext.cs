using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftStacksTechnologies.Models;

namespace SoftStacksTechnologies.DataBaseContext
{
    public class AccountContext:IdentityDbContext
    {
        public AccountContext(DbContextOptions<AccountContext> opt):base(opt)
        {
            
        }

        public DbSet<Admin> AdminTable {  get; set; }
        public DbSet<Student> StudentsTable { get; set; }
        public DbSet<Teacher> TeachersTable { get; set;}
    }
}
