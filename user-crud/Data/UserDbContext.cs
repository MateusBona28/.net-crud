using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.Data {

    public class UserDbContext : DbContext {
        
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}