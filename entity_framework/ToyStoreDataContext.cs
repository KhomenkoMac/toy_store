using Microsoft.EntityFrameworkCore;
using System;
using toy_store.domain.Models;

namespace entity_framework
{
    public class ToyStoreDataContext: DbContext
    {
        public ToyStoreDataContext(DbContextOptions options): base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
