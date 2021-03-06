using Microsoft.EntityFrameworkCore;
using DAMVC.Models.DB;

namespace DAMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Beer> Beers { get; set; }
    }
}