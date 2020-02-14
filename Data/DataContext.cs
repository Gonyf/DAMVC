using Microsoft.EntityFrameworkCore;
using DAMVC.Models.DB;
using DAMVC.DTO;

namespace DAMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<DAMVC.DTO.BeerDTO> BeerDTO { get; set; }
    }
}