using System.Text;
using System.Data.Entity;
using FrameworkTricks.Application.Models;

namespace FrameworkTricks.Application.Services
{
    public class FrameworkTricksDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
