using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Domain;

namespace MusicWeb.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        
        }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<MusicWeb.Models.Domain.FavouritesSongs>? FavouritesSongs { get; set; }
        public DbSet<MusicWeb.Models.Domain.Genre>? Genre { get; set; }
    }
}
