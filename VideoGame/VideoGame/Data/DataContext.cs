using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGame.Data.Entities;

namespace VideoGame.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Riesgo> Riesgos { get; set; }

    }
}
