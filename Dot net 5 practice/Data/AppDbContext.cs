using Dot_net_5_practice.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dot_net_5_practice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}