using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persitence;
public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
}
