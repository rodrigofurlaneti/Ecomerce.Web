using Ecomerce.Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Web.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Register> Register { get; set; }
        public DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public DbSet<Legal> Legal { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CartPurchaseItem> CartPurchaseItem { get; set; }
    }
}
