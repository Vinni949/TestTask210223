using Microsoft.EntityFrameworkCore;

namespace TestTask210223.Models
{
    public class DBProduct:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DBProduct(DbContextOptions<DBProduct> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
