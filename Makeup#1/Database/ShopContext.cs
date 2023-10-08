using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MakeupClassLibrary.DomainModels;

namespace Makeup_1.Database
{
    public class ShopContext : IdentityDbContext<User>
    {


        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;

        public DbSet<Comment> Comments { get; set; } = default!;

        public DbSet<Image> Images { get; set; } = default!;

        public DbSet<OrderItem> OrderItems { get; set; } = default!;

        public DbSet<Order> Orders { get; set; } = default!;
    }
}
