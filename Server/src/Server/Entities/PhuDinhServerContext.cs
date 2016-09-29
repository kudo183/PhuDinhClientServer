using Microsoft.EntityFrameworkCore;

namespace Server.Entities
{
    public class PhuDinhServerContext : DbContext, huypq.SwaMiddleware.SwaIDbContext<User>
    {
        public PhuDinhServerContext(DbContextOptions<PhuDinhServerContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<KhoHang> KhoHang { get; set; }
    }
}
