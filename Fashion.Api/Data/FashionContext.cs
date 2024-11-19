using Microsoft.EntityFrameworkCore;
using Fashion.Api.Models;

namespace Fashion.Api.Data
{
    public class FashionContext : DbContext
    {
        public FashionContext(DbContextOptions<FashionContext> options) : base(options) { }

        public DbSet<ReadyToWear> ReadyToWearItems { get; set; }
        public DbSet<Bespoke> BespokeItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Accessories> AccessoriesItems { get; set; }
    }
}
