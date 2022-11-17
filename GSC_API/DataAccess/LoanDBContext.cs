using GSC_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GSC_API.DataAccess
{
    public class LoanDBContext: DbContext

    {
        public LoanDBContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Thing> Things { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol>  RoleModel { get; set; }
    }
}
