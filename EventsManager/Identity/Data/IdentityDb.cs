using EventsManager.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsManager.Identity.Data
{
    public class IdentityDb : IdentityDbContext<User, Role, string>
    {
        public IdentityDb(DbContextOptions<IdentityDb> options) : base(options)
        {
//            Database.Migrate();
        }

        #region Overrides of DbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

    }
}