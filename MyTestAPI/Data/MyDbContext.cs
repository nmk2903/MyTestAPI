using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyTestAPI.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) 
        {

        }
        #region DbSet
            public DbSet<HangHoa>? hangHoas { get; set; }
        #endregion
    }
}
