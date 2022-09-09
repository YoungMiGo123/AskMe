using AskMe.Core.Core.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Core.Core.Data.Context
{
    public class AskMeDbContext : IdentityDbContext<ApplicationUser>
    {
        public AskMeDbContext(DbContextOptions<AskMeDbContext> options) : base(options)
        {

        }
        public AskMeDbContext()
        {

        }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
