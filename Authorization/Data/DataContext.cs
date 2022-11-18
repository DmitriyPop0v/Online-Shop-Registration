using Authorization.auth;
using Microsoft.EntityFrameworkCore;

namespace WebApiHotel.Data
{
    public class DataContext:DbContext
    {
        public DbSet<UserModel> users => Set<UserModel>();
        public DataContext(DbContextOptions<DataContext> dbContextOptions ): base(dbContextOptions)
        {
            this.Database.Migrate();
        }
        
    }
}
