using Microsoft.EntityFrameworkCore;

namespace CrudOperation.NetCore.Models
{
    /// <summary>
    /// create the database context
    /// </summary>
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options ) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
