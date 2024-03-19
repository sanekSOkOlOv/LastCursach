using Microsoft.EntityFrameworkCore;

namespace MYCARS.Models
{
    public class MyCarDbContext : DbContext
    {
        public MyCarDbContext(DbContextOptions<MyCarDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Skateboard> Skateboards { get; set; }
    }
}
