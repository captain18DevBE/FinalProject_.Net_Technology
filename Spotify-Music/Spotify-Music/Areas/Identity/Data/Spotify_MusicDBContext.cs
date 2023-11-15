using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spotify_Music.Areas.Identity.Data;

namespace Spotify_Music.Data;

public class Spotify_MusicDBContext : IdentityDbContext<Spotify_MusicUser>
{
    public Spotify_MusicDBContext(DbContextOptions<Spotify_MusicDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
