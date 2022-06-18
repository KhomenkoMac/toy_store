using entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace entity_framework
{
    public class ToyStoreDataContext: DbContext
    {
        public ToyStoreDataContext(DbContextOptions options): base(options) { }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProfileToy> ProfileToy { get; set; }
    }
}
