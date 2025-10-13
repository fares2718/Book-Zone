using Microsoft.EntityFrameworkCore;

namespace BookZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            :base(contextOptions)
        {
                
        }
    }
}
